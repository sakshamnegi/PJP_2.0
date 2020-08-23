package com.sapient.per_capita_income_calculator.services;

import java.util.List;

import com.sapient.per_capita_income_calculator.models.OutputEntity;

public interface ReportGenerator {

	void generateReport(List<OutputEntity> outputList, String outputFilename);

}
