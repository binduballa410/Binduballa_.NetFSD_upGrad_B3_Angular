export const calculateTotal = (marks) => {
    return marks.reduce((sum, marks) => sum + marks, 0);
};
export const calculateAverage = (marks) =>
{
    return calculateTotal(marks) / marks.length;
};
export const getResult = (average) => {
    return average >= 40 ? "Pass" : "Fail";
};