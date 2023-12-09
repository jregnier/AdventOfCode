﻿using Problem7;

const string HANDS_INPUT_EXAMPLE = @"
jjjjj 900
32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

const string HANDS_INPUT = @"
6JA22 162
TQJQ8 732
7T77A 882
6K66K 850
QQAQQ 11
7QQ7Q 321
28966 921
34433 801
8QQ8Q 914
K63K5 636
47777 533
K62Q9 773
25J52 717
A6AAA 631
23222 720
267Q4 9
K8QK5 15
QQA22 400
563T8 50
2J5J2 756
77T83 647
T9596 27
53AJA 371
6J666 916
833TK 380
5TK4J 506
TK3KK 794
JTJ55 54
TTT4T 422
9J3KK 491
488K4 30
87878 654
QQKKK 894
A4A3J 360
55559 232
33388 148
JK599 632
KK663 300
JJ448 514
AKATA 188
6J537 885
98888 65
9TT3J 361
668A9 227
Q3285 257
JT54J 208
K8QA7 373
77K39 681
33T4J 281
KA832 578
6QQQ5 214
52222 154
6A4Q4 78
39339 282
2A82A 25
5A66J 261
5594J 4
TTTT6 752
9A3K5 760
KA5AA 26
K7464 447
33676 605
K7J7A 946
5T5KQ 805
654Q8 888
35358 315
A4A57 552
669AA 485
7A77Q 105
Q3333 372
57A9Q 665
97655 367
24222 698
Q6KT7 820
99KKK 83
T33JK 389
9KKQ2 602
TT9JQ 278
JT5KJ 638
88JJ7 588
4664J 205
36T95 193
7272K 329
JTTTK 328
7K79T 653
84948 192
4444K 258
578QA 337
9J999 980
JT4A2 950
QJT22 598
TTTTJ 384
QAKJK 310
58955 547
Q2497 264
55444 746
793K4 256
QKQ5Q 802
ATTTT 878
Q92K5 469
88388 969
T99TQ 456
44384 560
3773J 545
82293 224
8558J 879
TT98T 342
AJKJ4 490
T9996 238
TKQQQ 810
J5Q55 229
Q564Q 932
4K6KJ 349
3J939 909
28K2K 563
8787K 262
JTK34 365
A3832 165
2T3A8 562
229Q5 761
9TTK9 58
KK55T 536
K6JJJ 216
44466 940
67777 897
QQ9Q9 963
48AJT 507
4TT4T 160
82936 584
99TTJ 597
698QA 573
398K5 618
56J54 438
45584 124
83657 892
J2782 574
68862 270
5Q5A7 132
TKK8K 288
6AT55 689
22J62 61
QJQ55 884
2J445 713
TJ952 913
3QAJ4 347
J73JK 122
555TT 64
AQ829 830
5384A 924
44446 146
Q7JTT 248
73K3K 22
22572 335
55JJJ 225
K56KK 587
9Q8TT 745
833QQ 420
63828 489
J6368 199
45464 31
72724 550
66Q6Q 543
66334 191
55Q54 965
KK7A7 73
TJQ8A 806
33Q23 283
928J3 804
4J4Q4 470
4KKKK 865
Q6K9K 266
7QJ2Q 237
7AT65 723
9TAJ2 327
73344 207
44TKK 179
86T68 203
TTT28 519
4J684 391
97779 169
9229K 593
KKK77 280
J2224 926
A5J5A 472
Q673J 697
K88KK 823
7K63J 198
4A65T 115
J2424 302
55A55 424
TTTQ6 142
48888 97
KK66T 672
7J7T7 809
4A444 153
3A33A 494
A7K25 790
88A9A 880
KQ549 473
6J2Q7 803
QQK2J 345
9KKJT 152
T4KJT 917
23593 608
33383 798
44Q22 841
AQQQT 709
7747Q 1
4333A 959
4666Q 163
AA5A5 920
7A77A 576
55J4K 357
6KKQT 354
A6866 837
JK6KT 341
QQQQ8 778
966Q9 710
59995 101
7KKJ2 79
4J58Q 680
K55KK 967
A3AAT 352
Q435J 20
453JJ 683
9T4QK 669
595J9 307
KK35K 673
98563 113
QJ943 181
88498 340
AKAAA 931
Q58Q5 183
QJAKT 145
3K8TA 952
JKA2J 173
JA734 443
68226 291
QT7J5 777
AAT8Q 377
T9T3T 991
44T75 642
79772 96
2Q5QQ 881
8TTTT 398
22K2J 45
46TQQ 497
QQ522 7
6JA99 35
TK65T 559
65885 532
76868 156
74J4J 274
Q85JQ 378
596K7 566
AJ522 286
5K455 362
483JJ 170
8JQ78 866
QQ3Q3 392
52292 250
77977 678
55AA3 604
33663 571
9KKKT 759
K8243 923
363J7 603
3333K 332
94333 660
555T5 98
5772A 206
TTTQT 103
Q3KJ2 29
99669 674
6625J 338
Q4444 904
7K6Q8 40
A73JA 646
77545 231
QTJ87 956
Q944Q 872
K8892 393
5AQ6T 503
7K7K7 322
74297 851
4QKJ6 508
Q665Q 114
8Q93T 825
AAA8T 799
6598K 910
78A27 766
JAAJA 993
88788 763
Q7925 117
A22A2 74
98T95 716
2QQQ3 75
A3479 107
KAKAK 13
8863K 271
J668A 919
342TA 62
6295A 226
T398T 558
54696 699
J444T 614
34442 41
86488 815
88T8T 755
78Q76 548
A6666 725
422TK 768
JJTTK 998
99393 730
967JQ 771
J9A94 500
KKQQ3 213
6TJ6K 899
K88KJ 346
52J22 835
J8827 651
5A588 67
333A3 737
J2J22 331
4Q3J6 953
7K443 601
A2868 355
TQ2K3 492
765Q2 521
AJ7AA 121
5J5J5 172
48A44 627
57TAA 891
58555 912
46436 195
K9AT3 859
78338 84
54J75 186
TTTTK 740
75777 461
25K5T 401
94994 272
5679Q 129
64666 375
327A9 243
7Q7QT 656
JAAAK 691
4AA4A 877
T5TTK 682
599QJ 395
3835K 502
46667 906
44443 408
5J558 430
5QJ44 670
3K693 585
33393 277
QQ992 849
4T4KT 368
99996 323
2QTT9 542
K253A 971
7799J 482
59QQ7 939
53633 405
4Q2Q2 677
9KQKK 975
78877 428
9KAJ6 987
JJ8JJ 951
46A6A 979
8K58J 915
433J4 304
33QTQ 657
8KKKK 167
J5J35 439
979J9 827
JK47Q 968
AAAJA 936
9747K 46
4449J 100
T7AJ6 204
5556Q 517
666T6 870
38QJA 57
277T7 764
4J834 964
22626 128
2334T 664
449Q4 454
6T6T6 590
TATAT 233
37555 609
ATK69 249
K33JK 784
J8JJ8 19
8T888 202
555AA 111
T3339 86
5Q963 816
7AK2K 650
J9J27 509
JJQQQ 436
59958 705
KKJAK 833
33K63 623
47764 690
58855 501
4754K 177
T5K5J 451
554Q4 762
99J29 595
6668J 621
7KK7J 795
46J56 465
28228 985
33J3J 343
J28J6 76
292T2 774
K99K9 459
2KTT5 147
AJQ3K 836
87JT7 744
97KJ6 524
82T2J 425
KJJ43 200
55KJ5 130
Q7985 718
777T7 846
QT46J 864
TAJ6A 520
A666A 493
75555 477
37878 930
TA882 306
Q93Q9 793
9JT99 954
993T9 643
28AK8 235
KJ69T 228
96869 102
24884 403
769AJ 867
6J434 47
6TTQ9 990
8T7TT 748
795AJ 753
84JKA 629
8J428 855
JJ2J9 997
TJ524 818
26662 686
567AA 219
97997 275
QQQ66 853
JQ77Q 692
66TTT 984
95353 16
8QQ7J 955
22272 814
8A868 616
6Q2QQ 983
KQKQQ 770
JJ66J 69
7KQJQ 505
J9J97 23
85ATA 986
A64KA 89
96669 684
9Q538 414
6AT62 427
JJ956 415
T24QQ 409
3277A 28
JA5TK 125
2586Q 157
K93QA 311
AA3TJ 960
34434 640
8J448 977
55333 267
T3TT3 667
55856 610
J375Q 873
344JQ 18
38J2K 36
QJ225 523
656A6 313
33J33 875
2JQ4A 480
AA4TA 3
TT3KJ 668
59996 933
A5AQK 104
AQ382 10
56A64 487
QQJA5 854
666K6 402
474AA 546
QAQAQ 452
ATQ32 171
7A777 861
Q4A9K 324
39Q26 247
29229 309
2QQ2Q 450
47424 394
2A2JA 55
7TAA9 687
9JTK4 661
KKK66 786
99989 839
59JK6 675
3QTTT 455
48TT6 780
542K6 397
79A56 471
QQQQ3 903
J2296 817
AQ52K 194
65A9K 842
9998J 246
2835K 662
74444 437
2754Q 685
98J67 907
8T8TT 134
343Q7 406
999T9 511
59JQQ 240
27KTT 973
AAKA9 577
3A223 840
QK787 655
K5977 754
JATQ7 468
6TT6A 464
99JJ9 564
2K242 320
66766 223
Q858Q 442
55T22 658
77QQ7 379
44JJ5 648
TK498 48
9J4J2 580
95945 957
A64J8 385
86666 242
8AA88 150
67877 77
AA999 144
J32J5 498
777TT 938
KJKKK 929
72689 353
684TA 970
JK8JK 92
56656 483
TTTT3 363
8T88K 868
AKAAK 382
42A7A 80
44349 474
37A7A 180
2QAA2 976
Q68K6 704
3373J 141
77666 279
9TTTK 49
36QT5 724
5T6JT 751
T257A 556
TA44J 59
AAATA 293
KKJ2K 410
7J64Q 871
2AQQ4 269
8777K 708
7K42T 594
22J22 775
899K8 918
53355 639
44429 326
7K777 944
573J7 221
T7A2Q 149
92242 579
5K7K6 63
386QK 722
JKQQQ 516
KA6A7 8
A9T28 633
T4Q67 220
KK233 962
AJ73J 831
KJ344 876
22277 635
99833 215
46JT7 42
QQQT3 88
88445 947
J7T55 935
29J22 44
5777J 178
999TT 230
J82TT 488
K3K9T 336
4T474 285
J5T54 53
KK7JK 433
K3374 908
55QTQ 95
665J5 453
35TQA 6
J2QQJ 630
6JK36 386
743J5 292
3Q9QQ 495
4JJ44 344
88285 534
766J4 553
QJ846 700
AAAA8 263
5655A 351
K67T8 197
3TA9A 460
8T9T8 481
TAJA9 526
8822J 742
4Q44K 625
K6663 110
AAA7A 32
432KK 726
KK288 540
67677 527
33882 693
QQQ35 316
J4Q4J 863
6639J 898
248QK 847
AA99J 758
T7QTT 383
AA442 572
JJJJJ 900
3353T 297
Q68A3 479
222KK 339
7J878 586
9292J 38
79QQQ 883
87J73 276
7488K 175
5J59A 421
67222 314
9K9KJ 449
JK447 528
KKKAK 303
A84A4 222
K6KJA 273
8T5QA 848
33352 591
AT833 617
2AAAA 305
3Q74K 555
24K44 739
3J342 925
QJK65 356
72333 807
J2AAA 750
K7779 554
33J45 886
79J96 895
9T6Q3 413
K3A4J 94
4T525 974
63333 418
55KK5 829
J4896 531
J8T8J 118
35435 741
722Q3 513
A3QAQ 72
3J8A6 958
T9QQ2 376
QA7AQ 287
9A555 348
T559T 695
4T774 999
22253 68
38838 772
462QJ 112
969K9 981
Q55Q5 992
J5555 14
Q565Q 995
755J5 510
KJKK9 189
J6T42 529
2748K 241
769T4 120
7K5TJ 845
Q2272 515
KTKKK 60
49J24 71
TT2J2 844
858J8 781
42643 364
TJ44J 448
QQQQ9 504
QQJQ6 37
J7974 796
T549Q 434
398J7 137
K6K55 161
TKTQQ 476
A9898 703
6J9K3 808
KK29J 201
QQ9J9 736
KKJKJ 712
66KJK 486
73777 82
824T6 496
78847 404
JQQ22 441
QQQQ4 694
555Q8 776
J7J7T 407
43Q6K 91
6T6K6 196
J66J6 308
54844 334
K9T44 457
K444K 135
38343 860
34323 735
KKK5J 734
4339J 541
JJQJ4 707
28222 972
KJA53 676
KKKK6 158
8Q558 783
T2TT2 34
74J67 209
5KKKK 945
9TTTT 412
66363 70
9399J 858
7J3TQ 589
7K468 116
3TA6Q 133
42Q6T 396
65886 557
449J9 728
8KT2J 446
J8888 822
2T266 927
8955K 138
QQQ5Q 943
92272 318
AA77J 1000
8TT66 569
T8AJ3 606
AT98K 628
34Q92 641
75QK5 499
8TJ93 155
KK7K5 176
JA859 21
9K523 727
K44JK 582
2Q8AQ 942
J5565 611
888K8 265
98982 747
K6866 982
883J3 538
6K6J6 767
7423J 2
QTQQT 252
4T4JT 812
5TT28 599
69766 440
QJ777 136
Q48J3 260
QQQJQ 253
7T994 989
A4Q4T 93
88K78 645
JA2QJ 797
55TJ3 151
JKQ96 696
99299 312
7777J 126
7437J 769
2Q382 620
2T5KK 298
Q4JJ5 333
8JJ88 874
QK33T 52
KTKTT 634
A7298 811
7J766 652
JAA5A 966
85385 702
5JK35 369
223J2 432
AAA33 56
3AA35 824
29222 423
6AA6A 212
29228 551
A22TT 996
J423Q 289
99J94 843
A364K 592
A4AAA 787
96TA2 706
Q3Q4Q 994
9334A 887
45555 857
AJ6AA 893
4J444 174
9JQ9J 731
9J964 143
K44KK 429
29JA8 159
53523 359
59Q23 522
A3663 24
53AAA 12
T7982 5
8Q888 140
A36J9 928
83668 961
28J2J 435
25Q42 659
ATK7Q 185
26855 462
J4624 567
97994 644
57989 109
KK883 417
JT676 721
T2222 51
34TTA 679
JTTJT 370
67267 463
A444Q 325
J77TT 813
24555 245
9TKJ8 612
48464 792
35K33 366
2A333 626
64A57 583
K3QJ6 43
24K86 244
28744 164
589Q4 688
A8888 896
6J626 666
65666 182
J3QJ5 387
QJK99 467
59455 889
3K555 330
35K35 832
A3KAA 106
Q6JQ6 81
KK2K2 838
79999 828
24A64 561
47JK9 785
77772 284
9T7T6 765
573Q5 934
4Q479 431
JJKAT 184
799JA 596
5QK5Q 411
TJ522 911
9A95A 87
5Q82Q 988
KTJJJ 294
566J3 729
7JA65 218
99J59 901
49K5T 301
5QQQ5 478
55552 39
99AAA 210
5665Q 649
2J822 530
QTTTQ 622
998J8 374
44222 600
77J7J 259
63888 782
93763 458
222TT 123
22T44 821
37KQQ 714
J688A 127
244QQ 581
33K3K 852
TJTJQ 738
TT2TQ 399
QTQ54 549
7T543 131
999A9 800
T435T 788
T3JQK 637
T725Q 358
59955 862
2J227 905
2T2TQ 99
9K7T5 119
987J7 296
77J55 779
KAJK8 711
8TJA7 168
666Q2 535
9J2T8 255
8J6J5 187
9JK44 743
55888 749
8KQJ4 733
T3399 570
TJT97 236
82597 890
TAAA7 715
AA797 268
27AA8 17
TTJAJ 317
984JA 624
56JA5 701
68668 819
75575 419
66626 613
4Q962 671
9Q898 484
95994 757
T3T33 615
3Q397 619
89747 381
6429A 922
J6996 254
Q3Q43 568
48864 416
678QA 388
TT5TT 239
69K6K 85
7667A 512
QJ9QQ 949
AJA5J 789
8JAJA 663
88AAK 575
3Q77J 295
6T4Q6 856
3856Q 539
47747 466
Q5T75 444
39A69 90
59956 299
J3JQ2 869
T65JK 941
74488 166
QAKTK 139
88668 251
KTTKK 190
88989 290
KKKK9 475
Q7JQ6 607
8K6T4 33
37968 834
48884 426
T929T 902
2KT54 217
86439 66
344J4 518
46664 350
J5392 537
74TT4 445
2J247 319
K66AT 565
39327 390
Q6656 525
75757 544
88688 108
486A6 978
72KQ3 826
277QQ 234
KK399 948
QJ828 791
97697 211
KKK6J 719
AA5TT 937";

//var hands = Hand.Parse(HANDS_INPUT_EXAMPLE);
var hands = Hand.Parse(HANDS_INPUT);

Console.WriteLine($"Total winnings: {hands.Sum(x => x.GetWinnings())}");