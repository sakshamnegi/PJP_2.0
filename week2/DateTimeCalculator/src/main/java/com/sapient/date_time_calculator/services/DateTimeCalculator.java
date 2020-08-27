package com.sapient.date_time_calculator.services;

import java.util.List;

import com.sapient.date_time_calculator.models.InputEntity;

public interface DateTimeCalculator {

	List<String> calculateDates(List<InputEntity> inputList);

	String addToDate(InputEntity ip);

	String subtractFromDate(InputEntity ip);

	String dayOfTheWeek(InputEntity ip);

	String weekOfTheYear(InputEntity ip);

}
