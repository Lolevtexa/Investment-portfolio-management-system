/// <summary>
/// Класс для металлов
/// </summary>
public class Metal : Investment
{
/// <summary>
/// Вес металла
/// </summary>
    private int Weight { get; set; }

/// <summary>
/// Цена за грамм
/// </summary>
    private decimal PricePerGram { get; set; }

/// <summary>
/// Конструктор
/// <para>name - название металла</para>
/// <para>maxCount - максимальное количество покупок металла</para>
/// <para>weight - вес металла</para>
/// <para>pricePerGram - цена за грамм</para>
/// </summary>
/// <param name="name">name - название металла</param>
/// <param name="maxCount">maxCount - максимальное количество покупок металла</param>
/// <param name="weight">weight - вес металла</param>
/// <param name="pricePerGram">pricePerGram - цена за грамм</param>
/// <returns>Объект класса Metal</returns>
    public Metal(string name, int maxCount, int weight, decimal pricePerGram)
        : base(name, maxCount)
    {
        Weight = weight;
        PricePerGram = pricePerGram;
    }

/// <summary>
/// Расчет стоимости инвестиции
/// <para>Стоимость металла = вес металла * цена за грамм</para>
/// </summary>
    public override int InvestmentCost()
    {
        return (int)(Weight * PricePerGram);
    }
    

/// <summary>
/// Расчет доходности инвестиции
/// <para>Доходность металла = вес металла * цена за грамм</para>
/// </summary>
/// <returns>Доходность металла</returns>
    public override decimal CalculateProfitability()
    {
        return Count * Weight * PricePerGram;
    }

/// <summary>
/// Переопределение метода ToString()
/// </summary>
/// <returns>Строка вида: Название металла (максимум Количество штук, вес одной штуки Вес, цена за грамм Цена)</returns>
    public override string ToString()
    {
        return $"{Name} (максимум {MaxCount} штук, вес одной штуки {Weight}, цена за грамм {PricePerGram})";
    }
}
