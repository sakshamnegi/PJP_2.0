package com.sapient.date_time_calculator;

import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import com.sapient.date_time_calculator.models.InputEntity;
import com.sapient.date_time_calculator.services.MyApplicationRunner;

@SpringBootTest
class DateTimeCalculatorApplicationTests {

	@Autowired
	MyApplicationRunner runner;

	@Test
	void performOperationsShouldReturnEmptyListForEmptyInputList() {
		List<InputEntity> inputList = new ArrayList<InputEntity>();

		List<String> res = runner.performOperations(inputList);
		assertEquals(0, res.size());
	}

}
