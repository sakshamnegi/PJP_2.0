package com.sapient.date_time_calculator.services;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import org.springframework.stereotype.Component;

import com.sapient.date_time_calculator.models.DateOperation;
import com.sapient.date_time_calculator.models.InputEntity;

@Component
public class ConsoleInputReader implements InputReader {

	private static Scanner input = new Scanner(System.in);
	private static final String DATE_PATTERN = "dd/MM/yyyy";
	DateTimeFormatter formatter = DateTimeFormatter.ofPattern(DATE_PATTERN);

	@Override
	public List<InputEntity> readInput() {
		List<InputEntity> list = new ArrayList<InputEntity>();
		int choice;
		do {
			System.out.println("Enter Date in Format " + DATE_PATTERN);
			String str = input.next();
			input.nextLine();// flushing endline
			LocalDate date = LocalDate.parse(str, formatter);
			System.out.println("Choose Operation");
			System.out.println("1. Add \n2.Subtract\n3. Determine day of week\n4. Determine week number");
			int ch = input.nextInt();
			input.nextLine();// flushing endline
			DateOperation operation;
			int[] params = null;
			operation = ch == 1 ? DateOperation.ADD : DateOperation.SUBTRACT;
			switch (ch) {
			case 1:
				// fall through to next case
			case 2:
				System.out.println("Enter days, weeks, months, years to " + (ch == 1 ? "Add" : "Subtract")
						+ " in the Format : 'days weeks months year'");
				String op = input.nextLine();
				String dateStr[] = op.split(" ");
				params = new int[] { 0, 0, 0, 0 };
				for (int i = 0; i < dateStr.length; i++) {
					params[i] = Integer.parseInt(dateStr[i]);
				}
				break;
			case 3:
				operation = DateOperation.DAY_OF_WEEK;
				break;
			case 4:
				operation = DateOperation.WEEK_OF_YEAR;
				break;
			default:
				System.out.println("Wrong choice. Exiting from Input Reader");
				return list;
			}
			list.add(new InputEntity(date, params, operation));
			System.out.println("Want to enter more?  1.Yes  2.No");
			choice = input.nextInt();
			input.nextLine();
		} while (choice == 1);
		return list;
	}

}
