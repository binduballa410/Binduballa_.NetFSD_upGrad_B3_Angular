import {
    calculateTotal, calculateAverage, getResult } from "./marksAnalyzer.js";
    const marks = [70, 80, 60, 50, 35];
    const total = calculateTotal(marks);
    const average = calculateAverage(marks);
    const result = getResult(average);

    console.log(`
        Student Marks: ${marks.join(", ")}
        Total: ${total}
        Average: ${average}
        Result: ${result}
        `);


