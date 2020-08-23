package com.sapient.per_capita_income_calculator.services;

import java.util.HashMap;
import java.util.Map;

import com.sapient.per_capita_income_calculator.models.Currency;

public class DollarConverter {

	private static Map<Currency, Double> conversionRules = new HashMap<Currency, Double>();

	static {
		conversionRules.put(Currency.INR, new Double((double) 1 / 66));
		conversionRules.put(Currency.GBP, new Double((double) 1 / 0.67));
		conversionRules.put(Currency.SGD, new Double((double) 1 / 1.5));
		conversionRules.put(Currency.HKD, new Double((double) 1 / 8));
		conversionRules.put(Currency.USD, new Double(1));
	}


	public double amountToDollar(double amount, Currency currency) {

		return amount * conversionRules.get(currency);
	}

}
