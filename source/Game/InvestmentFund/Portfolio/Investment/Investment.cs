/// <summary>
/// Базовый класс для инвестиций
/// </summary>
public abstract class Investment
{
/// <summary>
/// Название инвестиции
/// </summary>
    public string Name { get; private set; }

/// <summary>
/// Количество покупок инвестиции
/// </summary>
    protected int Count { get; set; }

/// <summary>
/// Максимальное количество покупок инвестиции
/// </summary>
    protected int MaxCount { get; set; }


/// <summary>
/// Конструктор
/// <para>name - название инвестиции</para>
/// <para>maxCount - максимальное количество покупок инвестиции</para>
/// </summary>
/// <param name="name">name - название инвестиции</param>
/// <param name="maxCount">maxCount - максимальное количество покупок инвестиции</param>
/// <returns>Объект класса Investment</returns>
    public Investment(string name, int maxCount)
    {
        Name = name;
        MaxCount = maxCount;
    }

/// <summary>
/// Расчет стоимости инвестиции
/// </summary>
/// <returns>Стоимость инвестиции</returns>
    public abstract int InvestmentCost();

/// <summary>
/// Максимальное количество покупок инвестиции
/// </summary>
/// <returns>Максимальное количество покупок инвестиции</returns>
    public virtual int GetMaxCount()
    {
        return MaxCount - Count;
    }

/// <summary>
/// Покупка инвестиции
/// </summary>
/// <param name="count">Количество покупок</param>
    public virtual void Buy(int count)
    {
        Count += count;
    }

/// <summary>
/// Продажа инвестиции
/// </summary>
/// <param name="count">Количество продаж</param>
    public virtual void Sell(int count)
    {
        Count -= count;
    }

/// <summary>
/// Расчет доходности инвестиции
/// <para>Доходность инвестиции = сумма инвестиции * процентная ставка</para>
/// </summary>
/// <returns>Доходность инвестиции</returns>
    public abstract decimal CalculateProfitability();

/// <summary>
/// Переопределение метода ToString()
/// </summary>
/// <returns>Строка с названием инвестиции, доходностью и максимально-доступном для покупки количеством</returns>
    public abstract override string ToString();
}
