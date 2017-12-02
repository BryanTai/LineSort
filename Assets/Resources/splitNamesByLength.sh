#!/bin/bash

LENGTH=2
MAX=11

while [ $LENGTH -le $MAX ]; do
	OUTFILE="merandaNamesSortedLength$LENGTH.txt"
	echo Processing names of length $LENGTH to $OUTFILE...
	grep -E "^[[:alpha:]]{$LENGTH}$" $1 > $OUTFILE
	let "LENGTH++"
done
