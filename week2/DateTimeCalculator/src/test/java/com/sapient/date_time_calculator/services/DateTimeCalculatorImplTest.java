package com.sapient.date_time_calculator.services;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.time.LocalDate;
import java.time.Month;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;

import com.sapient.date_time_calculator.models.DateOperation;
import com.sapient.date_time_calculator.models.InputEntity;

class DateTimeCalculatorImplTest {

	static DateTimeCalculator calculator;

	@BeforeAll
	static void setup() {
		calculator = new DateTimeCalculatorImpl();
	}

	@Test
	void addToDateShouldReturnGivenDateStrings() {
		assertEquals("27/04/2004", calculator.addToDate(
				new InputEntity(LocalDate.of(2000, Month.JANUARY, 12), new int[] { 1, 2, 3, 4 }, DateOperation.ADD)));
		assertEquals("23/05/1997", calculator.addToDate(
				new InputEntity(LocalDate.of(1997, Month.APRIL, 21), new int[] { 2, 0, 1, 0 }, DateOperation.ADD)));

	}

	@Test
	void subtractFromDateShouldReturnGivenResultString() {
		assertEquals("28/09/1995", calculator.subtractFromDate(new InputEntity(LocalDate.of(2000, Month.JANUARY, 12),
				new int[] { 1, 2, 3, 4 }, DateOperation.SUBTRACT)));
		assertEquals("19/02/1997", calculator.subtractFromDate(new InputEntity(LocalDate.of(1997, Month.APRIL, 21),
				new int[] { 2, 0, 2, 0 }, DateOperation.SUBTRACT)));

	}

	@Test
	void dayOfTheWeekTestShouldReturnGivenResultString() {

		assertEquals("3", calculator.dayOfTheWeek(new InputEntity(LocalDate.of(2020, Month.AUGUST, 26),
				new int[] { 0, 0, 0, 0 }, DateOperation.DAY_OF_WEEK)));

		assertEquals("1", calculator.dayOfTheWeek(new InputEntity(LocalDate.of(2021, Month.JULY, 12),
				new int[] { 0, 0, 0, 0 }, DateOperation.DAY_OF_WEEK)));

	}

	@Test
	void weekOfTheYearShouldReturnGivenResultString() {

		assertEquals("8", calculator.weekOfTheYear(new InputEntity(LocalDate.of(1999, Month.FEBRUARY, 28),
				new int[] { 0, 0, 0, 0 }, DateOperation.WEEK_OF_YEAR)));

		assertEquals("53", calculator.weekOfTheYear(new InputEntity(LocalDate.of(1999, Month.JANUARY, 3),
				new int[] { 0, 0, 0, 0 }, DateOperation.WEEK_OF_YEAR)));
		assertEquals("53", calculator.weekOfTheYear(new InputEntity(LocalDate.of(2000, Month.JANUARY, 2),
				new int[] { 0, 0, 0, 0 }, DateOperation.WEEK_OF_YEAR)));
		assertEquals("1", calculator.weekOfTheYear(new InputEntity(LocalDate.of(2040, Month.JANUARY, 2),
				new int[] { 0, 0, 0, 0 }, DateOperation.WEEK_OF_YEAR)));
		assertEquals("53", calculator.weekOfTheYear(new InputEntity(LocalDate.of(2040, Month.JANUARY, 1),
				new int[] { 0, 0, 0, 0 }, DateOperation.WEEK_OF_YEAR)));

	}

}
