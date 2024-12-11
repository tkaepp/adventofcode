mod daytwo;
mod dayone;
mod day3;
mod day4;

use eyre::Result;
fn main() -> Result<()> {
    // dayone::day1_first()?;
    // dayone::day1_second()?;
    // 
    // let _ = daytwo::part1_sample();
    // let _ = daytwo::part1_real();
    // let _ = daytwo::part2_real();
    // 
    // day3::part1_real()?;
    // day3::part2_real()?;
    
    day4::part1_sample()?;
    day4::part1_real()?;
    
    Ok(())
}

