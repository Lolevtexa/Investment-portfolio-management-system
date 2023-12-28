/// <summary>
/// Класс для инвестиционного фонда
/// </summary>
public class InvestmentFund
{
/// <summary>
/// Капитал фонда
/// </summary>
    private decimal Capital { get; set; }

/// <summary>
/// Портфель инвестиций
/// </summary>
    private Portfolio Portfolio { get; set; }

/// <summary>
/// Налоги
/// </summary>
    private decimal Taxes { get; set; }

/// <summary>
/// Конструктор
/// </summary>
    public InvestmentFund(decimal initialCapital)
    {
        Capital = initialCapital;
        Portfolio = new Portfolio();
        Taxes = 0.13m;
    }

/// <summary>
/// Расчет доходности инвестиций
/// <para>Описние расчета:</para>
/// <para>1. Расчет доходности портфеля</para>
/// <para>2. Прибавление доходности к капиталу</para>
/// <para>3. Вывод доходности портфеля и капитала</para>
/// <para>4. Вывод капитала фонда</para>
/// </summary>
    public void CalculateInvestmentReturns()
    {
        decimal portfolioProfitability = Portfolio.CalculatePortfolioProfitability();
        Capital += portfolioProfitability;
        
        ConsoleHelper.PrintWithDelay($"Доходность портфеля: {portfolioProfitability}");
        ConsoleHelper.PrintWithDelay($"Капитал фонда: {Capital}");
    }

/// <summary>
/// Оплата налогов
/// <para>Описние оплаты налогов:</para>
/// <para>1. Расчет налогов</para>
/// <para>2. Вычитание налогов из капитала</para>
/// <para>3. Вывод налогов и капитала</para>
/// <para>4. Вывод капитала фонда</para>
/// </summary>
    public void PayTaxes()
    {
        decimal taxes = Capital * Taxes;
        Capital -= taxes;
        ConsoleHelper.PrintWithDelay($"Налоги: {taxes}");
        ConsoleHelper.PrintWithDelay($"Капитал фонда: {Capital}");
    }

/// <summary>
/// Учет новых поступлений и расходов
/// <para>Описние учета:</para>
/// <para>1. Прибавление новых поступлений к капиталу</para>
/// <para>2. Вычитание новых расходов из капитала</para>
/// <para>3. Вывод капитала фонда</para>
/// </summary>
    public void AccountForNewIncomeAndExpenses(decimal newIncome, decimal newExpenses)
    {
        Capital += newIncome;
        Capital -= newExpenses;
        ConsoleHelper.PrintWithDelay($"Капитал фонда: {Capital}");
    }

/// <summary>
/// Покупка инвестиции
/// <para>Описние покупки:</para>
/// <para>1. Проверка наличия средств</para>
/// <para>2. Вычитание средств из капитала</para>
/// <para>3. Покупка инвестиции в портфель</para>
/// <para>4. Вывод капитала фонда</para>
/// </summary>
    public void BuyInvestment(Investment investment)
    {
        int maxBuyCount = (int)(Capital / investment.InvestmentCost());
        maxBuyCount = System.Math.Min(maxBuyCount, investment.GetMaxCount());

        string investmentType = "";
        switch (investment)
        {
            case Stock:
                investmentType = "акции";
                break;
            case Bond:
                investmentType = "облигации";
                break;
            case Metal:
                investmentType = "металла";
                break;
            case Deposit:
                investmentType = "вклада";
                break;
        }
        
        if (maxBuyCount == 0)
        {
            ConsoleHelper.PrintWithDelay($"Недостаточно средств для покупки {investmentType}");
            return;
        }

        switch (investment)
        {
            case Stock:
                investmentType = "количество покупаемых акций";
                break;
            case Bond:
                investmentType = "количество покупаемыхоблигаций";
                break;
            case Metal:
                investmentType = "количество покупаемого металла";
                break;
            case Deposit:
                investmentType = "сумму осуществляемого вклада";
                break;
        }
        ConsoleHelper.PrintWithDelay($"Доступно {maxBuyCount}. Введите {investmentType}:");
        int count = ConsoleHelper.ChoiceNumber(maxBuyCount);
        Portfolio.BuyInvestment(investment, count);
        Capital -= investment.InvestmentCost() * count;
        ConsoleHelper.PrintWithDelay($"Капитал фонда: {Capital}");
    }

    /// <summary>
    /// Продажа инвестиции
    /// <para>Описние продажи:</para>
    /// <para>1. Прибавление средств к капиталу</para>
    /// <para>2. Продажа инвестиции из портфеля</para>
    /// <para>3. Вывод капитала фонда</para>
    /// </summary>
    public void SellInvestment(Investment investment)
    {
        int maxSellCount = investment.GetMaxCount();
        if (maxSellCount == 0)
        {
            ConsoleHelper.PrintWithDelay("Нет инвестиций для продажи");
            return;
        }

        ConsoleHelper.PrintWithDelay($"Введите количество продаваемых инвестиций (максимум {maxSellCount}):");
        int count = ConsoleHelper.ChoiceNumber(maxSellCount);
        Portfolio.SellInvestment(investment, count);
        Capital += investment.InvestmentCost() * count;
    }
}
