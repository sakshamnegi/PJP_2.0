package com.sapient.processing_fee_calculator.services;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import com.sapient.processing_fee_calculator.models.Transaction;

public class CSVRecordsReader implements RecordsReader {

	@Override
	public List<Transaction> readRecords(String filename) {
		List<Transaction> list = new ArrayList<Transaction>();
		try (BufferedReader bufferedReader = new BufferedReader(new FileReader(filename))) {

			String line;
			while ((line = bufferedReader.readLine()) != null) {
				String[] transaction = line.split(",");
				list.add(new Transaction(transaction));
			}
			return list;
		}catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return list;
	}


	}
