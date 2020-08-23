package com.sapient.per_capita_income_calculator.services;

import java.util.List;
import java.util.Map;

import com.sapient.per_capita_income_calculator.models.InputEntity;

public interface RecordsReader {

	Map<String, List<InputEntity>> readRecords(String inputFilename);
}
