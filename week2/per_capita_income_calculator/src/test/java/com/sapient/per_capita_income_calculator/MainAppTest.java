package com.sapient.per_capita_income_calculator;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.fail;

import java.util.Arrays;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import org.junit.Test;

import com.sapient.per_capita_income_calculator.models.Currency;
import com.sapient.per_capita_income_calculator.models.Gender;
import com.sapient.per_capita_income_calculator.models.InputEntity;
import com.sapient.per_capita_income_calculator.models.OutputEntity;

/**
 * Unit test for simple App.
 */
public class MainAppTest 
{
    /**
     * Rigorous Test :-)
     */



	@Test
	public void readInputShouldReadGivenMapForGivenInput() {
		String inputFilename = "sample-input-readTest.csv";
		Map<String, List<InputEntity>> expectedMap = new TreeMap<String, List<InputEntity>>();
		expectedMap.put("ENGLAND", Arrays.asList(new InputEntity("LONDON", "ENGLAND", Gender.M, Currency.GBP, 10000)));
		expectedMap.put("LONDON",
				Arrays.asList(new InputEntity("LONDON", "Not Available", Gender.F, Currency.GBP, 15000)));
		expectedMap.put("INDIA",
				Arrays.asList(new InputEntity("DELHI", "INDIA", Gender.F, Currency.INR, 50000),
						new InputEntity("NOIDA", "INDIA", Gender.M, Currency.INR, 10000),
						new InputEntity("DELHI", "INDIA", Gender.F, Currency.INR, 55000)));

		Map<String, List<InputEntity>> recordsMap = MainApp.readInput(inputFilename);

		if (recordsMap.size() != expectedMap.size()) {
			fail();
		}
		for (String key : recordsMap.keySet()) {
			if (recordsMap.get(key).size() != expectedMap.get(key).size()) {
				fail();
			}
			for (int i = 0; i < recordsMap.get(key).size(); i++) {
				InputEntity actual = recordsMap.get(key).get(i);
				InputEntity expected = expectedMap.get(key).get(i);

				assertEquals(expected.getCity(), actual.getCity());
				assertEquals(expected.getCountry(), actual.getCountry());
				assertEquals(expected.getGender(), actual.getGender());
				assertEquals(expected.getCurrency(), actual.getCurrency());
				assertEquals(expected.getAmount(), actual.getAmount(), 0.1);

			}
		}
	}

    @Test
	public void calculatePerCapitaIncomeShouldReturnGivenListForGivenSampleInput()
    {
		String inputFilename = "sample-input.csv";

		List<OutputEntity> opList = Arrays.asList(new OutputEntity("BANGALORE", Gender.F, 1363.64),
				new OutputEntity("BANGALORE", Gender.M, 1401.52), new OutputEntity("CALIFORNIA", Gender.F, 23000.0),
				new OutputEntity("CALIFORNIA", Gender.M, 19500.0), new OutputEntity("ENGLAND", Gender.F, 17910.45),
				new OutputEntity("ENGLAND", Gender.M, 19402.99), new OutputEntity("INDIA", Gender.F, 858.59),
				new OutputEntity("INDIA", Gender.M, 151.52),
				new OutputEntity("USA", Gender.F, 20000.0),
				new OutputEntity("USA", Gender.M, 19000.0));

		Map<String, List<InputEntity>> recordsMap;
		recordsMap = MainApp.readInput(inputFilename);

		List<OutputEntity> calculatedList = MainApp.calculatePerCapitaIncome(recordsMap);
		if(opList.size()!= calculatedList.size()) {
			fail();
		}
		for(int i=0; i<opList.size(); i++) {

			// debug
			// System.out.println(opList.get(i).getGender() + " " +
			// calculatedList.get(i).getGender());
			assertEquals(opList.get(i).getGender(), calculatedList.get(i).getGender());
			// System.out.println(opList.get(i).getPerCapitaIncome() + " " +
			// calculatedList.get(i).getPerCapitaIncome());
			assertEquals(opList.get(i).getPerCapitaIncome(), calculatedList.get(i).getPerCapitaIncome(), 0.1);
			// System.out.println(opList.get(i).getPlace() + " " +
			// calculatedList.get(i).getPlace());
			assertEquals(opList.get(i).getPlace(), calculatedList.get(i).getPlace());
		}
		
		
    }
}
