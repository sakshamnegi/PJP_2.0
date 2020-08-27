package com.sapient.date_time_calculator.models;

import java.time.LocalDate;

public class OutputEntity {

	private LocalDate date;
	private int[] params;
	private DateOperation operation;
	private String result;

	public OutputEntity(LocalDate date, int[] params, DateOperation operation, String result) {
		super();
		this.date = date;
		this.params = params;
		this.operation = operation;
		this.result = result;
	}

	public LocalDate getDate() {
		return date;
	}

	public void setDate(LocalDate date) {
		this.date = date;
	}

	public int[] getParams() {
		return params;
	}

	public void setParams(int[] params) {
		this.params = params;
	}

	public DateOperation getOperation() {
		return operation;
	}

	public void setOperation(DateOperation operation) {
		this.operation = operation;
	}

	public String getResult() {
		return result;
	}

	public void setResult(String result) {
		this.result = result;
	}

}
