package com.sapient.per_capita_income_calculator.models;

public class OutputEntity {

	private String place;
	private Gender gender;
	private double perCapitaIncome;

	public OutputEntity(String place, Gender gender, double perCapitaIncome) {
		super();
		this.place = place;
		this.gender = gender;
		this.perCapitaIncome = perCapitaIncome;
	}

	public String getPlace() {
		return place;
	}

	public void setPlace(String place) {
		this.place = place;
	}

	public Gender getGender() {
		return gender;
	}

	public void setGender(Gender gender) {
		this.gender = gender;
	}

	public double getPerCapitaIncome() {
		return perCapitaIncome;
	}

	public void setPerCapitaIncome(double perCapitaIncome) {
		this.perCapitaIncome = perCapitaIncome;
	}

}
