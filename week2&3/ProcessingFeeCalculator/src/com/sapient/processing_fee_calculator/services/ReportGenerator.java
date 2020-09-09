package com.sapient.processing_fee_calculator.services;

import java.util.List;

import com.sapient.processing_fee_calculator.models.Transaction;

public interface ReportGenerator {

	void generateReport(List<Transaction> transactions, String outputFilename);

}
