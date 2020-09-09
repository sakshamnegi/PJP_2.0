package com.sapient.processing_fee_calculator.models;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;


public class Transaction {

	private String extTransactionID;
	private String clientID;
	private String securityID;
	private TransactionType transactionType;
	private Date transactionDate;
	private double marketValue;
	private PriorityFlag priorityFlag;
	private double processingFee;

	// string array from csv to transaction object
	public Transaction(String[] transaction) {
		this.extTransactionID = transaction[0];
		this.clientID = transaction[1];
		this.securityID = transaction[2];
		this.transactionType = TransactionType.valueOf(transaction[3].toUpperCase());
		try {
			this.transactionDate = new SimpleDateFormat("MM/dd/yyy").parse(transaction[4]);
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		this.marketValue = Double.valueOf(transaction[5]);
		this.priorityFlag = PriorityFlag.valueOf(transaction[6].toUpperCase());

	}

	public String getExtTransactionID() {
		return extTransactionID;
	}

	public void setExtTransactionID(String extTransactionID) {
		this.extTransactionID = extTransactionID;
	}

	public String getClientID() {
		return clientID;
	}

	public void setClientID(String clientID) {
		this.clientID = clientID;
	}

	public String getSecurityID() {
		return securityID;
	}

	public void setSecurityID(String securityID) {
		this.securityID = securityID;
	}

	public TransactionType getTransactionType() {
		return transactionType;
	}

	public void setTransactionType(TransactionType transactionType) {
		this.transactionType = transactionType;
	}

	public Date getTransactionDate() {
		return transactionDate;
	}

	public void setTransactionDate(Date transactionDate) {
		this.transactionDate = transactionDate;
	}

	public double getMarketValue() {
		return marketValue;
	}

	public void setMarketValue(double marketValue) {
		this.marketValue = marketValue;
	}

	public PriorityFlag getPriorityFlag() {
		return priorityFlag;
	}

	public void setPriorityFlag(PriorityFlag priorityFlag) {
		this.priorityFlag = priorityFlag;
	}

	public double getProcessingFee() {
		return processingFee;
	}

	public void setProcessingFee(double processingFee) {
		this.processingFee = processingFee;
	}

}
