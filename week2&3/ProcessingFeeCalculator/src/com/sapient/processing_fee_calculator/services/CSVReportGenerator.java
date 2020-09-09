package com.sapient.processing_fee_calculator.services;

import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import com.sapient.processing_fee_calculator.models.Transaction;

public class CSVReportGenerator implements ReportGenerator {

	@Override
	public void generateReport(List<Transaction> transactions, String outputFilename) {
		Comparator<Transaction> clientIDComparator = (t1, t2) -> t1.getClientID().compareTo(t2.getClientID());
		Collections.sort(transactions, clientIDComparator);
		try(FileWriter fr = new FileWriter(outputFilename)){
			fr.append("Client Id");
			fr.append(",");
			fr.append("Transaction Type");
			fr.append(",");
			fr.append("Transaction Date");
			fr.append(",");
			fr.append("Priority");
			fr.append(",");
			fr.append("Processing Fee");
			fr.append("\n\n");
			
			
			for (Transaction t : transactions) {

				fr.append(String.join(",", t.getClientID(), 
						t.getTransactionType().name(),
						new SimpleDateFormat("MM/dd/yyyy").format(t
								.getTransactionDate()),
						t.getPriorityFlag().name(),
						String.valueOf(t.getProcessingFee())));
				fr.append('\n');
			}
			fr.flush();
			fr.close();

			System.out.println("CSV Report Generated Successfully");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}



}
