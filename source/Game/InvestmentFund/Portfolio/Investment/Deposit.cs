/// <summary>
/// Класс для вкладов
/// </summary>
public class Deposit : Investment
{
/// <summary>
/// Максимальная сумма вклада
/// </summary>
    private int MaxAmount { get; set; }

/// <summary>
/// Сумма вклада
/// </summary>
    private int Amount { get; set; }

/// <summary>
/// Процентная ставка
/// </summary>
    private decimal InterestRate { get; set; }

/// <summary>
/// Конструктор
/// <para>name - название вклада</para>
/// <para>maxCount - максимальное количество покупок вклада</para>
/// <para>interestRate - процентная ставка</para>
/// </summary>
/// <param name="name">name - название вклада</param>
/// <param name="maxCount">maxCount - максимальное количество покупок вклада</param>
/// <param name="interestRate">interestRate - процентная ставка</param>
/// <returns>Объект класса Deposit</returns>
    public Deposit(string name, int maxAmount, decimal interestRate)
        : base(name, 1)
    {
        MaxAmount = maxAmount;
        InterestRate = interestRate;
    }

/// <summary>
/// Расчет стоимости инвестиции
/// <para>Стоимость вклада = сумма вклада</para>
/// </summary>
    public override int InvestmentCost()
    {
        return Amount;
    }

/// <summary>
/// Максимальное количество покупок инвестиции
/// </summary>
/// <returns>Максимальное количество покупок инвестиции</returns>
    public override int GetMaxCount()
    {
        return MaxAmount - Amount;
    }

/// <summary>
/// Покупка вклада
/// </summary>
/// <param name="amount">Сумма вклада</param>
    public override void Buy(int amount)
    {
        Amount += amount;
    }

/// <summary>
/// Продажа вклада
/// </summary>
    public override void Sell(int amount)
    {
        Amount -= 0;
    }
    
/// <summary>
/// Расчет доходности инвестиции
/// <para>Доходность вклада = сумма вклада * процентная ставка</para>
/// </summary>
/// <returns>Доходность вклада</returns>
    public override decimal CalculateProfitability()
    {
        return Amount * InterestRate;
    }

/// <summary>
/// Переопределение метода ToString()
/// </summary>
/// <returns>Строка вида: Название вклада (максимум Сумма рублей, процентная ставка Процент)</returns>
    public override string ToString()
    {
        return $"{Name} (максимум {MaxAmount} рублей, процентная ставка {InterestRate})";
    }
}
