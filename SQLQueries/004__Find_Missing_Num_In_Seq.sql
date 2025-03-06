SELECT Num-1 FROM Numbers
WHERE Num NOT IN (SELECT Num + 1 FROM Numbers)
  AND  Num-1 > 0;