mod daytwo;
mod dayone;

use eyre::Result;
fn main() -> Result<()> {
    dayone::day1_first()?;
    dayone::day1_second()?;

    let _ = daytwo::part1_sample();
    let _ = daytwo::part1_real();
    let _ = daytwo::part2_real();
    
    Ok(())
}

