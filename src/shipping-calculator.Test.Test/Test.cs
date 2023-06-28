using Xunit;
using System.IO;
using FluentAssertions;
using System;
using ShippingCalculator;

namespace ShippingCalculator.Test.Test;

public class TestReq1
{
    [Trait("Category", "1. Calcule o Frete por preço do pedido na função `CalculateShippingPrice`")]
    [Theory(DisplayName = "Deve calcular o frete por preço do pedido")]
    [InlineData(40, 25)]
    [InlineData(50, 25)]
    [InlineData(50.01, 20)]
    [InlineData(70, 20)]
    [InlineData(100, 20)]
    [InlineData(100.01, 15)]
    [InlineData(150, 15)]
    [InlineData(200, 15)]
    [InlineData(200.01, 0)]
    [InlineData(600, 0)]
    public void TestShippingPrice(double orderPrice, double shippingPrice)
    {
        var calculator = new ShippingCalculator();
        var value = calculator.calculateShippingPrice(orderPrice);
        Assert.Equal(value, shippingPrice);
    }

}

public class TestReq2
{
    [Trait("Category", "2. Calcule o Frete por peso na função `CalculateShippingWeight`")]
    [Theory(DisplayName = "Deve calcular o frete por peso")]
    [InlineData(1.4, 3.8)]
    [InlineData(1.5, 3.8)]
    [InlineData(1.51, 5.7)]
    [InlineData(2.4, 5.7)]
    [InlineData(3.5, 5.7)]
    [InlineData(3.51, 7.2)]
    [InlineData(5.6, 7.2)]
    [InlineData(7.0, 7.2)]
    [InlineData(7.01, 9.4)]
    [InlineData(8.5, 9.4)]
    [InlineData(10.0, 9.4)]
    [InlineData(10.01, 19.019)]
    [InlineData(20, 38)]
    [InlineData(30, 57)]
    public void TestShippingWeight(double weight, double shippingWeight)
    {
        var calculator = new ShippingCalculator();
        var value = calculator.calculateShippingWeight(weight);
        Assert.Equal(value, shippingWeight);
    }
}


public class TestReq3
{
    [Trait("Category", "3. Calcule o Frete final na função `CalculateShipping`")]
    [Theory(DisplayName = "Deve calcular o frete final")]
    [InlineData(40, 1, 28.8)]
    [InlineData(40, 2, 30.7)]
    [InlineData(40, 5, 32.2)]
    [InlineData(40, 9, 34.4)]
    [InlineData(40, 20, 53.55)]
    [InlineData(70, 1, 23.8)]
    [InlineData(70, 2, 25.7)]
    [InlineData(70, 5, 27.2)]
    [InlineData(70, 9, 29.4)]
    [InlineData(70, 20, 49.3)]
    [InlineData(140, 1, 18.8)]
    [InlineData(140, 2, 20.7)]
    [InlineData(140, 5, 22.2)]
    [InlineData(140, 9, 24.4)]
    [InlineData(140, 20, 45.05)]
    [InlineData(250, 1, 3.8)]
    [InlineData(250, 2, 5.7)]
    [InlineData(250, 5, 7.2)]
    [InlineData(250, 9, 9.4)]
    [InlineData(250, 20, 38)]
    [InlineData(150, 15.789473684210527, 45)]
    public void TestShipping(double orderPrice, double weight, double shipping)
    {
        var calculator = new ShippingCalculator();
        var value = calculator.calculateShipping(orderPrice, weight);
        Assert.Equal(value, shipping);
    }
}

public class TestReq4
{
    [Trait("Category", "4. Calcule o Frete final para um array de preços e um array de pesos na função `CalculateShippingFromArray`")]
    [Theory(DisplayName = "Deve calcular o frete final do array de itens")]
    [InlineData(new double[] { 40, 70, 140, 250 }, new double[] { 1, 2, 5, 9 }, 32.3)]
    [InlineData(new double[] { 40, 70, 140, 250, 40 }, new double[] { 1, 2, 5, 9, 1 }, 34.199999999999996)]
    [InlineData(new double[] { 40, 70, 140, 250, 70, 120 }, new double[] { 1, 2, 5, 9, 5, 2 }, 38.75999999999999)]
    [InlineData(new double[] { 40, 70, 140, 250, 170, 150, 130 }, new double[] { 1, 2, 5, 9, 2, 5, 9 }, 53.294999999999995)]
    public void TestShippingFromArray(double[] orderPrices, double[] weights, double finalShippingPrice)
    {
        var calculator = new ShippingCalculator();
        var value = calculator.calculateShippingFromArray(orderPrices, weights);
        Assert.Equal(value, finalShippingPrice);
    }
}