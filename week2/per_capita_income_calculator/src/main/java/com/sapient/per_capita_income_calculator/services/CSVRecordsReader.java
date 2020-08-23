package com.sapient.per_capita_income_calculator.services;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

import com.sapient.per_capita_income_calculator.models.Currency;
import com.sapient.per_capita_income_calculator.models.Gender;
import com.sapient.per_capita_income_calculator.models.InputEntity;

public class CSVRecordsReader implements RecordsReader {

	@Override
	public Map<String, List<InputEntity>> readRecords(String inputFilename) {

		Map<String, List<InputEntity>> recordMap = new TreeMap<String, List<InputEntity>>();
		try (BufferedReader bufferedReader = new BufferedReader(new FileReader(inputFilename))) {
			String line;
			while ((line = bufferedReader.readLine()) != null) {
				String key;
				int offset;
				String[] records = line.split(",");
				if(records.length == 4) {
					key = records[0].toUpperCase();
					offset = -1;
							
				}
				else {
					key = records[1].toUpperCase();
					offset = 0;
				}
				InputEntity newInputEntity = new InputEntity(records[0].toUpperCase(), offset == 0 ? records[1]
						.toUpperCase()
						: "Not Available",
								Gender.valueOf(records[2+offset]),
								Currency.valueOf(records[3+offset].toUpperCase()), 
						Double.valueOf(records[4 + offset]));
				
				if (!recordMap.containsKey(key)) {
					recordMap.put(key, new ArrayList<InputEntity>());
				}
				recordMap.get(key).add(newInputEntity);

			}
			return recordMap;
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

		return recordMap;
	}



}
