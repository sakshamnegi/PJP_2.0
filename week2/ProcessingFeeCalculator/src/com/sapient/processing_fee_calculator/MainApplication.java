package com.sapient.processing_fee_calculator;

import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.sapient.processing_fee_calculator.models.PriorityFlag;
import com.sapient.processing_fee_calculator.models.Transaction;
import com.sapient.processing_fee_calculator.models.TransactionType;
import com.sapient.processing_fee_calculator.services.CSVRecordsReader;
import com.sapient.processing_fee_calculator.services.CSVReportGenerator;
import com.sapient.processing_fee_calculator.services.RecordsReader;
import com.sapient.processing_fee_calculator.services.ReportGenerator;

public class MainApplication {

	private static List<Transaction> transactions;

	// can be autowired with Spring
	private static RecordsReader recordsReader;
	private static ReportGenerator reportGenerator;

	static {
		recordsReader = new CSVRecordsReader();
		reportGenerator = new CSVReportGenerator();
	}

	// needs input and output file names as parameters from command line
	public static void main(String[] args) {

		String inputFilename = "SampleTransactions.csv";
		String outputFilename = "Report.csv";

		readTransactions(inputFilename);

		processTransactions();

		generateTransactionReport(outputFilename);
	}

	public static void readTransactions(String inputFilename) {

		transactions = recordsReader.readRecords(inputFilename);
	}

	public static void processTransactions() {

		// Normal Transactions
		for (Transaction t : transactions) {
			if (t.getPriorityFlag() == PriorityFlag.Y) {
				t.setProcessingFee(500);
			} else {
				TransactionType type = t.getTransactionType();
				if (type == TransactionType.SELL || type == TransactionType.WITHDRAW) {
					t.setProcessingFee(100);
				} else if (type == TransactionType.BUY || type == TransactionType.DEPOSIT) {
					t.setProcessingFee(50);
				}
			}
		}
		
		Map<TransactionType, TransactionType> typeMap = new HashMap<TransactionType, TransactionType>();
		typeMap.put(TransactionType.BUY, TransactionType.SELL);
		typeMap.put(TransactionType.SELL, TransactionType.BUY);
		typeMap.put(TransactionType.WITHDRAW, TransactionType.DEPOSIT);
		typeMap.put(TransactionType.DEPOSIT, TransactionType.WITHDRAW);
		

		// System.out.println("BEFORE+++++++++++++");
		// System.out.println(transactions);
		// intra day transactions
		// checking if client id, security id and date are same
		// and transaction types are opposite
		Comparator<Transaction> intraDayComparater = (t1, t2) -> {
			if(t1.getClientID().equals(t2.getClientID()) 
					&& t1.getSecurityID().equals(t2.getSecurityID()) 
					&& t1.getTransactionDate().equals(t2.getTransactionDate())
					&& (t1.getTransactionType() == typeMap.get(t2.getTransactionType()))) {
				// System.out.println("intra-day spotted");
				t1.setProcessingFee(t1.getProcessingFee()+10);
				t2.setProcessingFee(t2.getProcessingFee()+10);
				return (int) (t1.getProcessingFee()-t2.getProcessingFee());
			}
			else {
				return 
						t1.getClientID().compareTo(t2.getClientID());
			}
		};
		
		Collections.sort(transactions, intraDayComparater);
		// System.out.println("AFTER+++++++++++++");
		// System.out.println(transactions);
		

	}

	public static void generateTransactionReport(String outputFilename) {

		reportGenerator.generateReport(transactions, outputFilename);

	}

}
