// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S15.9.5.15_A1_T1;
 * @section: 15.9.5.15;
 * @assertion: The Date.prototype property "getUTCDate" has { DontEnum } attributes;
 * @description: Checking absence of ReadOnly attribute;
 */

x = Date.prototype.getUTCDate;
if(x === 1)
  Date.prototype.getUTCDate = 2;
else
  Date.prototype.getUTCDate = 1;
if (Date.prototype.getUTCDate === x) {
  $ERROR('#1: The Date.prototype.getUTCDate has not the attribute ReadOnly');
}

