mod daytwo;

use std::collections::{HashMap, HashSet};
use std::collections::hash_map::Entry;
use eyre::Result;
use std::fs::read_to_string;

use std::io::Lines;

fn main() -> Result<()> {
    day1_first()?;
    day1_second()?;

    let _ = daytwo::part1_sample();
    let _ = daytwo::part1_real();
    let _ = daytwo::part2_real();
    
    Ok(())
}

fn day1_first() -> Result<()> {
    let filename = "input/d1-1.txt";

    let mut left_values: Vec<i32> = Vec::new();
    let mut right_values: Vec<i32> = Vec::new();

    for line in read_to_string(filename)?.lines() {
        let mut splitted = line.split("   ");

        left_values.push(splitted.next().unwrap().parse()?);
        right_values.push(splitted.next().unwrap().parse()?);
    }

    left_values.sort();
    right_values.sort();

    let mut sum: i32 = 0;
    for i in 0..left_values.len()
    {
        let distance = (left_values[i] - right_values[i]).abs();
        sum += distance;
    }

    println!("{}", sum);
    Ok(())
}

fn day1_second() -> Result<()> {
    // let filename = "input/d1-sample.txt";
    let filename = "input/d1-2.txt";

    let mut left_values: Vec<i32> = Vec::new();
    let mut right_values: HashMap<i32, i32> = HashMap::new();

    for line in read_to_string(filename)?.lines() {
        let mut splitted = line.split("   ");

        left_values.push(splitted.next().unwrap().parse()?);
        *right_values.entry(splitted.next().unwrap().parse()?).or_insert(0) +=1;
    }

    let mut sum: i32 = 0;
    for i in 0..left_values.len()
    {
        let left = left_values[i];

        let value = right_values.get(&left).unwrap_or(&0);
        let similarity = left * value;
        sum += similarity;
    }

    println!("{}", sum);
    Ok(())
}
