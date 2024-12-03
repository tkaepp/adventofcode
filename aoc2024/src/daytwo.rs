use eyre::Result;
use std::cmp::Ordering;
use std::fs::read_to_string;

pub fn part1_sample() -> Result<()> {
    let filename = "input/d2-1-sample.txt";

    /* So, a report only counts as safe if both of the following are true:

        The levels are either all increasing or all decreasing.
        Any two adjacent levels differ by at least one and at most three.
    */
    let safe_reports = day2_part1(filename)?;

    println!("Day 2 Sample: {}", safe_reports);

    Ok(())
}

pub fn part1_real() -> Result<()> {
    let filename = "input/d2-1.txt";

    /* So, a report only counts as safe if both of the following are true:

        The levels are either all increasing or all decreasing.
        Any two adjacent levels differ by at least one and at most three.
    */
    let safe_reports = day2_part1(filename)?;

    println!("Day 2 real: {}", safe_reports);

    Ok(())
}

pub fn part2_real() -> Result<()> {
    let filename = "input/d2-1.txt";

    /* So, a report only counts as safe if both of the following are true:

        The levels are either all increasing or all decreasing.
        Any two adjacent levels differ by at least one and at most three.
    */
    let safe_reports = day2_part2v2(filename)?;

    println!("Day 2 real: {}", safe_reports);

    Ok(())
}

fn day2_part1(filename: &str) -> Result<i32> {
    let mut safe_reports: i32 = 0;
    for line in read_to_string(filename)?.lines() {
        let mut splitted = line.split(" ");

        let report: Vec<i32> = splitted.map(|s| s.parse::<i32>().unwrap()).collect();

        let all_descending = report.windows(2).all(|arr| {
            let diff = (arr[0] - arr[1]).abs();

            arr[0] > arr[1] && diff >= 1 && diff <= 3
        });
        let all_ascending = report.windows(2).all(|arr| {
            let diff = (arr[0] - arr[1]).abs();

            arr[0] < arr[1] && diff >= 1 && diff <= 3
        });

        if all_ascending || all_descending {
            safe_reports += 1;
        }
    }
    Ok(safe_reports)
}

fn day2_part2(filename: &str) -> Result<i32> {
    let mut safe_reports: i32 = 0;
    for line in read_to_string(filename)?.lines() {
        let mut splitted = line.split(" ");

        let report: Vec<i32> = splitted.map(|s| s.parse::<i32>().unwrap()).collect();

        let mut first_error = true;
        let all_descending = report.windows(2).all(|arr| {
            let diff = (arr[0] - arr[1]).abs();

            if first_error {
                let mut is_valid = arr[0] > arr[1] && diff >= 1 && diff <= 3;
                if is_valid == false {
                    is_valid = true;
                    first_error = false;
                }

                is_valid
            } else {
                arr[0] > arr[1] && diff >= 1 && diff <= 3
            }
        });

        first_error = true;
        let all_ascending = report.windows(2).all(|arr| {
            let diff = (arr[0] - arr[1]).abs();

            if first_error {
                let mut is_valid = arr[0] < arr[1] && diff >= 1 && diff <= 3;
                if is_valid == false {
                    is_valid = true;
                    first_error = false;
                }
                
                is_valid
            } else {
                arr[0] < arr[1] && diff >= 1 && diff <= 3
            }
        });

        if all_ascending || all_descending {
            safe_reports += 1;
        }
    }
    Ok(safe_reports)
}

fn day2_part2v2(filename: &str) -> Result<i32> {
    let mut safe_reports: i32 = 0;
    for line in read_to_string(filename)?.lines() {
        let mut splitted = line.split(" ");

        let report: Vec<i32> = splitted.map(|s| s.parse::<i32>().unwrap()).collect();
        
        let mut permutations: Vec<Vec<i32>> = Vec::new();
        
        let initial = report.clone();
        
        permutations.push(initial);
        for i in 0..report.len() {
            let mut first_slice = report[0..i].to_vec();
            let mut second_slice = report[i+1..].to_vec();
            
            first_slice.append(&mut  second_slice);
            
            permutations.push(first_slice);
        }
        

        let all_descending = permutations.iter().any(all_descending);
        
        let all_ascending = permutations.iter().any(|r: &Vec<i32>| all_ascending(r.to_vec()));

        if all_ascending || all_descending {
            safe_reports += 1;
        }
    }
    Ok(safe_reports)
}

fn all_ascending(report: Vec<i32>) -> bool {
    report.windows(2).all(|arr| {
        let diff = (arr[0] - arr[1]).abs();

        arr[0] < arr[1] && diff >= 1 && diff <= 3
    })
}

fn all_descending(report: &Vec<i32>) -> bool {
    report.windows(2).all(|arr| {
        let diff = (arr[0] - arr[1]).abs();

        arr[0] > arr[1] && diff >= 1 && diff <= 3
    })
}
