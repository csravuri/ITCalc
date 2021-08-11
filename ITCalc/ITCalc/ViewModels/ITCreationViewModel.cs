using ITCalc.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ITCalc.ViewModels
{
    public class ITCreationViewModel : BaseViewModel
    {
        private const decimal fifteenLacs = 1500000;
        private const decimal twelveAndHalfLacs = 1250000;
        private const decimal tenLacs = 1000000;
        private const decimal sevenAndHalfLacs = 750000;
        private const decimal fiveLacs = 500000;
        private const decimal twoAndHalfLacs = 250000;

        private decimal netIncome;
        private decimal taxableIncome;
        private decimal deductions;
        private decimal oldTax;
        private decimal newTax;

        private bool isNotMetro = true;
        private decimal netSalary;
        private decimal bankInterest;
        private decimal otherIncome;

        private decimal epf;
        private decimal professionalTax;
        private decimal ppf;
        private decimal insurance;
        private decimal other80C;

        private decimal hra;
        private decimal standardDeduction = 50000;

        public decimal NetIncome
        {
            get => netIncome;
            set => SetProperty(ref netIncome, value);
        }

        public decimal TaxableIncome
        {
            get => taxableIncome;
            set => SetProperty(ref taxableIncome, value);
        }

        public decimal Deductions
        {
            get => deductions;
            set => SetProperty(ref deductions, value);
        }

        public decimal OldTax
        {
            get => oldTax;
            set => SetProperty(ref oldTax, value);
        }

        public decimal NewTax
        {
            get => newTax;
            set => SetProperty(ref newTax, value);
        }

        public bool IsNotMetro
        {
            get => isNotMetro;
            set => SetProperty(ref isNotMetro, value);
        }

        public decimal NetSalary
        {
            get => netSalary;
            set => SetProperty(ref netSalary, value);
        }

        public decimal BankInterest
        {
            get => bankInterest;
            set => SetProperty(ref bankInterest, value);
        }

        public decimal OtherIncome
        {
            get => otherIncome;
            set => SetProperty(ref otherIncome, value);
        }

        public decimal EPF
        {
            get => epf;
            set => SetProperty(ref epf, value);
        }

        public decimal ProfessionalTax
        {
            get => professionalTax;
            set => SetProperty(ref professionalTax, value);
        }

        public decimal PPF
        {
            get => ppf;
            set => SetProperty(ref ppf, value);
        }

        public decimal Insurance
        {
            get => insurance;
            set => SetProperty(ref insurance, value);
        }

        public decimal Other80C
        {
            get => other80C;
            set => SetProperty(ref other80C, value);
        }

        public decimal HRA
        {
            get => hra;
            set => SetProperty(ref hra, value);
        }

        public decimal StandardDeduction
        {
            get => standardDeduction;
        }


        public ICommand TextEnteredCommand { get; }
        public ICommand CalenderClickedCommand { get; }

        private Dictionary<string, Page> pageCache = new Dictionary<string, Page>();

        public ITCreationViewModel(INavigation navigation) : base(navigation)
        {
            TextEnteredCommand = new Command(() => ExecuteTextEnteredCommand());
            CalenderClickedCommand = new Command<string>(async (controlName) => await ExecuteCalenderClickedCommand(controlName));
        }

        private async Task ExecuteCalenderClickedCommand(string controlName)
        {
            if (!pageCache.TryGetValue(controlName, out Page page))
            {
                page = new MonthWiseDetails(new MonthWiseDetailsViewModel(Navigation));
            }

            await Navigation.PushModalAsync(page);
        }

        private void ExecuteTextEnteredCommand()
        {
            CalcuateAll();
        }

        private void CalcuateAll()
        {
            NetIncome = NetSalary + BankInterest + OtherIncome;
            Deductions = Math.Min(150000, EPF + PPF + Insurance + Other80C) + StandardDeduction + ProfessionalTax + HRA;
            TaxableIncome = Math.Max(0, NetIncome - Deductions);
            OldTax = GetOldTax(TaxableIncome);
            NewTax = GetNewTax(NetIncome);
            ApplyCessAndRound();
        }


        private decimal GetOldTax(decimal taxableIncome)
        {
            if (TaxableIncome <= fiveLacs)
            {
                return 0m;
            }

            if (taxableIncome > tenLacs)
            {
                return (taxableIncome - tenLacs) * 0.3m + GetOldTax(tenLacs);
            }
            else if (taxableIncome > fiveLacs && taxableIncome <= tenLacs)
            {
                return (taxableIncome - fiveLacs) * 0.2m + GetOldTax(fiveLacs);
            }
            else if (taxableIncome > twoAndHalfLacs && taxableIncome <= fiveLacs)
            {
                return (taxableIncome - twoAndHalfLacs) * 0.05m + GetOldTax(twoAndHalfLacs);
            }
            else if (taxableIncome <= twoAndHalfLacs)
            {
                return 0;
            }

            return 0;
        }

        private decimal GetNewTax(decimal taxableIncome)
        {


            if (taxableIncome > fifteenLacs)
            {
                return (taxableIncome - fifteenLacs) * 0.3m + GetNewTax(fifteenLacs);
            }
            else if (taxableIncome > twelveAndHalfLacs && taxableIncome <= fifteenLacs)
            {
                return (taxableIncome - twelveAndHalfLacs) * 0.25m + GetNewTax(twelveAndHalfLacs);
            }
            else if (taxableIncome > tenLacs && taxableIncome <= twelveAndHalfLacs)
            {
                return (taxableIncome - tenLacs) * 0.2m + GetNewTax(tenLacs);
            }
            else if (taxableIncome > sevenAndHalfLacs && taxableIncome <= tenLacs)
            {
                return (taxableIncome - sevenAndHalfLacs) * 0.15m + GetNewTax(sevenAndHalfLacs);
            }
            else if (taxableIncome > fiveLacs && taxableIncome <= sevenAndHalfLacs)
            {
                return (taxableIncome - fiveLacs) * 0.1m + GetNewTax(fiveLacs);
            }
            else if (taxableIncome > twoAndHalfLacs && taxableIncome <= fiveLacs)
            {
                return (taxableIncome - twoAndHalfLacs) * 0.05m + GetNewTax(twoAndHalfLacs);
            }
            else if (taxableIncome <= twoAndHalfLacs)
            {
                return 0;
            }

            return 0;
        }

        private void ApplyCessAndRound()
        {
            OldTax *= 1.04m;
            NewTax *= 1.04m;

            OldTax = Math.Round(OldTax, 0);
            NewTax = Math.Round(NewTax, 0);
        }
    }
}
