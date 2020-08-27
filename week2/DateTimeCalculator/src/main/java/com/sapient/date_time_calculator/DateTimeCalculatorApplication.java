package com.sapient.date_time_calculator;

import java.util.List;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;

import com.sapient.date_time_calculator.models.InputEntity;
import com.sapient.date_time_calculator.services.MyApplicationRunner;

@SpringBootApplication
public class DateTimeCalculatorApplication {

	public static void main(String[] args) {

		ConfigurableApplicationContext context = SpringApplication.run(DateTimeCalculatorApplication.class, args);

		MyApplicationRunner runner = context.getBean(MyApplicationRunner.class);

		List<InputEntity> inputList = runner.readDateInputs();

		List<String> resultList = runner.performOperations(inputList);

		runner.showResults(inputList, resultList);
	}

}
