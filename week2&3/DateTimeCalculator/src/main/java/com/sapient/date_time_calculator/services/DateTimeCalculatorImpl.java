package com.sapient.date_time_calculator.services;

import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.Month;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;

import com.sapient.date_time_calculator.models.InputEntity;

@Component
public class DateTimeCalculatorImpl implements DateTimeCalculator {

	@Override
	public List<String> calculateDates(List<InputEntity> inputList) {
		List<String> list = new ArrayList<String>();
		for (InputEntity ip : inputList) {
			switch (ip.getOperation()) {
			case ADD:
				list.add(addToDate(ip));
				break;
			case SUBTRACT:
				list.add(subtractFromDate(ip));
				break;
			case DAY_OF_WEEK:
				list.add(dayOfTheWeek(ip));
				break;
			case WEEK_OF_YEAR:
				list.add(weekOfTheYear(ip));
				break;
			}

		}
		return list;
	}

	@Override
	// params - int[3] of {days, weeks, months, years}
	public String addToDate(InputEntity ip) {

		LocalDate temp = ip.getDate();

		return temp.plusDays(ip.getParams()[0]).plusWeeks(ip.getParams()[1]).plusMonths(ip.getParams()[2])
				.plusYears(ip.getParams()[3]).format(DateTimeFormatter.ofPattern("dd/MM/yyyy"));
	}

	@Override
	// params - int[3] of {days, weeks, months, years}
	public String subtractFromDate(InputEntity ip) {

		LocalDate temp = ip.getDate();
		return temp.minusDays(ip.getParams()[0]).minusWeeks(ip.getParams()[1]).minusMonths(ip.getParams()[2])
				.minusYears(ip.getParams()[3]).format(DateTimeFormatter.ofPattern("dd/MM/yyyy"));
	}

	@Override
	public String dayOfTheWeek(InputEntity ip) {

		return String.valueOf(ip.getDate().getDayOfWeek().getValue());

	}

	@Override
	public String weekOfTheYear(InputEntity ip) {

		LocalDate tempDate = LocalDate.of(ip.getDate().getYear(), Month.JANUARY, 1);
		for (int i = 0; i < 7; i++) {
			if (tempDate.plusDays(i).getDayOfWeek() == DayOfWeek.MONDAY) {
				tempDate = tempDate.plusDays(i);
				break;
			}
		}
		int daysSince = ip.getDate().getDayOfYear() - tempDate.getDayOfYear();
		if (daysSince < 0) {
			return String.valueOf(53);
		}
		if (daysSince == 0) {
			return String.valueOf(1);
		}

		Double res = Math.ceil(daysSince / 7.0);
		return String.valueOf(res.intValue());

	}

}
