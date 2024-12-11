use eyre::Result;
use std::fs::read_to_string;
use std::str::CharIndices;

pub fn part1_sample() -> Result<()> {
    let filename = "input/d4-1-sample.txt";
    let filecontent = read_to_string(filename)?;

    let mut puzzle: Vec<Vec<char>>;
    const BOUNDRY: usize = 10;
    readfile(filecontent, &mut puzzle);

    let xmas = ['X', 'M', 'A', 'S'];
    let mut xmas_counter = 0;

    for i in 0..10 {
        for j in 0..10 {
            // read right i..i+4
            let current = xy(i, j);
            if let Some(search) = right(&puzzle, current, BOUNDRY * (i + 1)) {
                if search.eq(&xmas) {
                    println!("XMAS found");
                    xmas_counter += 1;
                }
            }

            // read diagonal right down i & j ++ per schritt
            // let ia = xy(i + 1, j + 1);
            // let ib = xy(i + 2, j + 2);
            // let ic = xy(i + 3, j + 3);
            // let id = xy(i + 4, j + 4);
            // let a = puzzle[ia];
            // let b = puzzle[ib];
            // let c = puzzle[ic];
            // let d = puzzle[id];
            // let char_array = [a, b, c, d];
            // if char_array.eq(&xmas) {
            //     println!("XMAS found");
            //     xmas_counter += 1;
            // }

            // read down j..j+4
            // read diagonal left down
            // read left
            // read diagnoal left up
            // read up
            // read diagonal right up
        }
    }

    println!("{}", xmas_counter);

    Ok(())
}

fn right(puzzle: &Vec<Vec<char>>, current: usize, boundry: usize) -> Option<[char; 4]> {
    if current + 4 > boundry {
        return None;
    }

    let asdf = puzzle[current..current + 4].as_ref();

    Some(<[char; 4]>::try_from(asdf).unwrap())
}

fn xy(i: usize, j: usize) -> usize {
    i * 10 + j
}

fn readfile(filecontent: String, puzzle: &mut Vec<Vec<char>>) {
    let mut i = 0;

    for row in filecontent.lines() {
        puzzle[i] = row.chars().collect();
    }
}

pub fn part1_real() -> Result<()> {
    let filename = "input/d4-1-sample.txt";
    let filecontent = read_to_string(filename)?;
    let mut puzzle: [char; 140 * 140] = ['.'; 140 * 140];

    readfile(filecontent, &mut puzzle);
    let result = 0;
    println!("{}", result);

    Ok(())
}

pub fn part2_real() -> Result<()> {
    let result = 0;
    println!("{}", result);

    Ok(())
}
