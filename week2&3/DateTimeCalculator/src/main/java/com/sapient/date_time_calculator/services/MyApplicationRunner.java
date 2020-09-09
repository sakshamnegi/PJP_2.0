package com.sapient.date_time_calculator.services;

import java.time.format.DateTimeFormatter;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.sapient.date_time_calculator.models.InputEntity;

@Component
public class MyApplicationRunner {

	@Autowired
	private DateTimeCalculator calculator;

	@Autowired
	private InputReader reader;

	public List<InputEntity> readDateInputs() {

		return reader.readInput();

	}

	public List<String> performOperations(List<InputEntity> inputList) {

		return calculator.calculateDates(inputList);

	}

	public void showResults(List<InputEntity> inputList, List<String> resultList) {

		System.out.println("========Results=========");
		System.out.println("Date, Operation, Params(days, weeks, months, years),  Result");
		StringBuilder params = new StringBuilder();
		for (int i = 0; i < inputList.size(); i++) {
			params.setLength(0);
			if (inputList.get(i).getParams() != null) {
				params.append('(');
				params.append(inputList.get(i).getParams()[0]);
				params.append(", ");
				params.append(inputList.get(i).getParams()[1]);
				params.append(", ");
				params.append(inputList.get(i).getParams()[2]);
				params.append(", ");
				params.append(inputList.get(i).getParams()[3]);
				params.append(')');
			} else {
				params.append("N/A");
			}
			System.out.println(inputList.get(i).getDate().format(DateTimeFormatter.ofPattern("dd/MM/yyy")) + "   "
					+ inputList.get(i).getOperation().name() + "   " + params.toString() + "   " + resultList.get(i));
		}
	}

}
