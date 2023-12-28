/// <summary>
/// Класс для акций
/// </summary>
public class Stock : Investment
{
/// <summary>
/// Цена за акцию
/// </summary>
    private int PricePerShare { get; set; }

/// <summary>
/// Конструктор
/// <para>name - название акции</para>
/// <para>maxCount - максимальное количество покупок акции</para>
/// <para>pricePerShare - цена за акцию</para>
/// </summary>
/// <param name="name">name - название акции</param>
/// <param name="maxCount">maxCount - максимальное количество покупок акции</param>
/// <param name="pricePerShare">pricePerShare - цена за акцию</param>
/// <returns>Объект класса Stock</returns>
    public Stock(string name, int maxCount, int pricePerShare)
        : base(name, maxCount)
    {
        PricePerShare = pricePerShare;
    }

/// <summary>
/// Расчет стоимости инвестиции
/// <para>Стоимость акции = количество акций * цена за акцию</para>
/// </summary>
    public override int InvestmentCost()
    {
        return PricePerShare;
    }

/// <summary>
/// Расчет доходности инвестиции
/// <para>Доходность акции = количество акций * цена за акцию</para>
/// </summary>
    public override decimal CalculateProfitability()
    {
        return Count * PricePerShare;
    }

/// <summary>
/// Переопределение метода ToString()
/// </summary>
/// <returns>Строка вида: Название акции (максимум Количество штук, цена за штуку Цена)</returns>
    public override string ToString()
    {
        return $"{Name} (максимум {MaxCount} штук, цена за штуку {PricePerShare})";
    }
}
