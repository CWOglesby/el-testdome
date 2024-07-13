// Question 6, input array is best guess from memory

// This file can be executed with Node.js on the command line:
//  > 'node testdome.js'

function getAverageBrightness(input) {
    let a = 0;
    let b = 0;

    // Initialize to max value, first calculated average will always be lower.
    let lowestAverage = Number.MAX_SAFE_INTEGER;

    input.forEach(current => {
        // Ignore failed measurements
        if (current === 0)
            return;

        // Set a and b first before computing average
        if (a === 0) {
            a = current;
            return;
        } else if (b === 0) {
            b = current;
            return;
        }

        let currentAverage = (a + b + current) / 3;
        lowestAverage = Math.min(lowestAverage, currentAverage);

        // Move sliding window to right
        a = b;
        b = current;
    });

    return lowestAverage;
}

console.log(getAverageBrightness([2,0,1,5,7,0,3,2,6,0]));