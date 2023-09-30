using WebDepozit.Data;
using WebDepozit.Models;
using WebDepozit.Services.Interface;

namespace WebDepozit.Services.Realization
{
    public class DepozitCalculateService : IDepozitCalculateService
    {
       private readonly DataContext dbContex;

       public DepozitCalculateService(DataContext dbContex) => this.dbContex = dbContex;



        private double CalculateMounthProcent(double yearprocent)
        {
            return (double)(Math.Pow((1.0 + (double)yearprocent / 100.0), 1 / 12D) - 1) * 100;
        }


        public MounthlyDepozitReport[] CalculateDifficultProcent(double startDepozit, double mounthPlus, double yearProcent, int terminInMounth)
        {


            MounthlyDepozitReport[] depozitReports = new MounthlyDepozitReport[terminInMounth];

            for (int i = 0; i < terminInMounth; i++)

            {
                var mounthlyDepozitReport = new MounthlyDepozitReport();

                double MounthlyIncome = startDepozit * (CalculateMounthProcent(yearProcent) / 100);
                startDepozit += MounthlyIncome;
                startDepozit += mounthPlus;

                mounthlyDepozitReport.NumberMounth = i + 1;
                mounthlyDepozitReport.MounthDepozit = startDepozit;
                mounthlyDepozitReport.MounthlyIncome = MounthlyIncome;
                mounthlyDepozitReport.MounthlyPlus = mounthPlus;

                depozitReports[i] = mounthlyDepozitReport;

              dbContex.MounthlyDepozitReports.Add(mounthlyDepozitReport);
              dbContex.SaveChanges();

            }

            return depozitReports;
        }
    }
}
