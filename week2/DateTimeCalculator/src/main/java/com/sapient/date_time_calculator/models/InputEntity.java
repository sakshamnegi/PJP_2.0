package com.sapient.date_time_calculator.models;

import java.time.LocalDate;

public class InputEntity {

	private LocalDate date;
	private int[] params;
	private DateOperation operation;

	public InputEntity(LocalDate date, int[] params, DateOperation operation) {
		super();
		this.date = date;
		this.params = params;
		this.operation = operation;
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

}
