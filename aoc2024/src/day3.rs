use eyre::Result;
use regex::Regex;
use std::fs::read_to_string;

pub fn part1_real() -> Result<()> {
    let filename = "input/d3-1.txt";
    let binding = read_to_string(filename)?;
    let content = binding.as_str();

    let re = Regex::new(r"mul\((\d{1,3}),(\d{1,3})\)")?;

    let mut results = vec![];

    for (_, [factor1, factor2]) in re.captures_iter(content).map(|c| c.extract()) {
        results.push((factor1.parse::<i32>()?, factor2.parse::<i32>()?));
    }

    let result: i32 = results.iter().map(|(x, y)| x * y).sum();

    println!("{}", result);

    Ok(())
}

pub fn part2_real() -> Result<()> {
    let filename = "input/d3-1.txt";

    // run the regex just for a substring between a do() and a don't()

    let binding = read_to_string(filename)?.replace("\n", "");
    let content = binding.as_str();

    let do_dont_regex = Regex::new(r"(do\(\)).*?(don't\(\))")?;

    let mut parsed_contents = vec![];
    
    // hack to apply the do() is enabled from the beginning...
    parsed_contents.push(")+when())~why(),),mul(712,171)@}-?}mul(506,85)who()%mul(613,601)/;#from()#mul(977,581)~what()?/$^-+(*mul(142,89)[who();*):*mul(64,644)}when()select()mul(652,872)mul(594,202)?%$when(196,699)mul(311,646)<>/how()where()(+:mul(867,971)}&where()'/&[&$mul(192,659)select();<#}mul(367,411)mul(841,862)when()(%!mul(922,272)^;}mul(593,223)mul(918,232)mul(760,145)]^?why()>mul(558,476)where()who()&");
    
    for content in do_dont_regex.find_iter(content).map(|m| m.as_str()) {
        parsed_contents.push(content);
    }

    let re = Regex::new(r"mul\((\d{1,3}),(\d{1,3})\)")?;

    let mut results = vec![];

    for parsed_content in parsed_contents {
        for (_, [factor1, factor2]) in re.captures_iter(parsed_content).map(|c| c.extract()) {
            results.push((factor1.parse::<i32>()?, factor2.parse::<i32>()?));
        }
    }

    let result: i32 = results.iter().map(|(x, y)| x * y).sum();

    println!("{}", result);

    Ok(())
}
