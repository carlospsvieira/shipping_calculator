using System;

namespace ShippingCalculator;

public class ShippingCalculator
{
    /// <summary>
    /// This function evaluates the order price passed as an input parameter and returns the shipping price following the exercise's logic
    /// </summary>
    /// <param name="orderPrice"> A value of type double, the order price </param>
    /// <returns>The shipping price value (integer type), following the exercise logic </returns>
    /// <exception cref="ArgumentException">If the order price be equal to or less than zero</exception>

    // 1 - Calcular o Frete por preço do pedido na função `CalculateShippingPrice`.
    public double calculateShippingPrice(double orderPrice)
    {
        switch (orderPrice) {
            case <= 50:
                return 25;
            case <= 100:
                return 20;
            case <= 200:
                return 15;
            default:
                return 0; 
        }
    }

    // 2 - Calcular o Frete por peso na função `CalculateShippingWeight`
    public double calculateShippingWeight(double weight)
    {
        switch (weight) {
            case <= 1.5:
                return 3.8;
            case <= 3.5:
                return 5.7;
            case <= 7:
                return 7.2;
            case <= 10:
                return 9.4;
            default:
                return weight * 1.9; 
        }
    }

    // 3 - Calcular o Frete final na função `CalculateShipping`
    public double calculateShipping(double orderPrice, double weight) {
        throw new NotImplementedException();
    }

    // 4 - Calcular o Frete final para um array de preços e um array de pesos na função `CalculateShippingFromArray`
    public double calculateShippingFromArray(double[] itemPrices, double[] itemWeights)
    {
        throw new NotImplementedException();
    }

}