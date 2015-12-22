/**
 * Fraction class used to create fraction objects,
 * with a numerator and denominator (like 3/4)
 *
 * Includes no, one, and two argument constructors, 
 * equals and toString methods, and methods to
 * reduce to lowest terms, add, subt, mult, div fraction
 * get/set methods are optional
 *
 * @author Dennis Lang
 * @modified Daniel Lovell
 * @version 10
 *
 */
using System;

public class Fraction {

	private int num;
	private int denom;

	/**
	 * Fraction creates a new fraction
	 *
	 * @param n The numerator
	 * @param d The denominator
 	 */
	public Fraction(int n, int d) {
		num = n;
		denom = d;
		Reduce();	// reduce within the constructor
	} // end constructor Fraction(int n, int d)

	/**
	 * Fraction creates a default fraction 1/1
	*/
	public Fraction() {
		num = 1;
		denom = 1;
	} // end constructor Fraction()

	/**
	 * Fraction creates a new fraction with a whole number
	 *
	 * @param n The numerator
	 * @param d The denominator
 	 */
	public Fraction(int n) {
		num = n;
		denom = 1;
	} // end constructor Fraction(int n)

	/**
	 * returns the fraction as a String
	 * in the from num/dem (like 3/4)
 	 */
	public override string ToString() {
		return (num + "/" + denom);
	} // end print

	/**
	 * modifies the numerator and denominator so the fraction
	 * is reduced to lowest terms
 	 */
	private void Reduce() {
		bool negative = false;	// assume not negative

		if (num < 0) {			// if negative, make positive before reducing
			negative = true;
			num = num * -1;
		} // end if

		int bound = num;		// test if values 2 through num are factors
		for (int i = 2; i <= bound; i++) {
			// if remainder is zero for both num & den, then factor
			if (num%i == 0 && denom%i == 0) {
				num = num/i;
				denom = denom/i;
				// have to check if values is again a factor
				//(EX: 80/120 =40/60=20/30=10/15)
				i--;
			} // end if
		} // end for
		// if negative, change back to negative after reducing
		if (negative) num = num * -1;
	} // end reduce

	/**
	 * plus adds this fraction to the parameter and returns the result
	 *
	 * @param f The fraction to add to
	 * @return This fraction plus f
 	 */
	public Fraction Plus(Fraction f) {
		int newNum = num*f.denom + f.num*denom;
		int newDenom = denom*f.denom;
		return new Fraction(newNum, newDenom);	// create and reduce new fraction
	} // end plus

	/**
	 * minus takes this fraction minus the parameter and returns the result
	 *
	 * @param f The fraction to subtract
	 * @return This fraction minus f
 	 */
	public Fraction Minus(Fraction f) {
		int newNum = num*f.denom - f.num*denom;
		int newDenom = denom*f.denom;
		return new Fraction(newNum, newDenom);	// create and reduce new fraction
	} // end minus

	/**
	 * times multiplies this fraction by the parameter and returns the result
	 *
	 * @param f The fraction to multiply by
	 * @return This fraction times f
 	 */
	public Fraction Times(Fraction f) {
		int newNum = num*f.num;
		int newDenom = denom*f.denom;
		return new Fraction(newNum, newDenom);	// create and reduce new fraction
	} // end times

	/**
	 * divide takes this fraction divided by the parameter and returns the result
	 *
	 * @param f The fraction to divide by
	 * @return This fraction divided by f
 	 */
	public Fraction Divide(Fraction f) {
		int newNum = num*f.denom;
		int newDenom = denom*f.num;
		return new Fraction(newNum, newDenom);	// create and reduce new fraction
	} // end divide

	/**
	 * equals determines if two reduced fractions have the same num/denom
	 *
	 * @param f The fraction to test for equality
	 * @return true if equal, else false
 	 */
	public bool Equals (Fraction f) {
		return ( f.num == this.num && f.denom == this.denom);
	} // end equals

} // end class Fraction
