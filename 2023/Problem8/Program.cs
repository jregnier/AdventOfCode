﻿using AocUtilities;

using Problem8;

const string INSTRUCTIONS_EXAMPLE = @"
LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";

const string INSTRUCTIONS = @"
LLRLRRRLLRRRLRRLRRLRLRRRLRRRLRLLRLRRLRRLRLLRRLRRRLRRLRLRLRLRRRLRRLRLLLRRLRRRLLLRLRRRLRRRLLRRLRRRLRLRRRLLLRRLLRRLRRLLLRRRLRRRLRRRLRRLLRLRLRLRRRLRLRLRRLRRLRLRRRLRRLRRRLRRRLLLRLRRLRRLRLLRRLLRRLRRLLRLRRLRRLRLRLLLRLLRRLRRLRRRLLRRLLRRRLRRLRRRLRRRLLRRRLRRRLLRRRLRLRLLRRLRLRLRRRR

CGM = (SFJ, BVH)
HRM = (PBG, QHK)
BJR = (JJM, BPB)
JTG = (RMK, GCR)
NSG = (QLT, LTH)
TJK = (TBJ, DTN)
HNX = (FCF, MCS)
MNC = (GCP, QBR)
KPH = (JDP, QMR)
SHD = (KGS, JXK)
VDM = (QLR, NVD)
VMT = (KHJ, SXN)
CLX = (XTB, GXS)
LBQ = (LFP, MVC)
XLR = (BGR, XSG)
XVK = (JLG, QGJ)
DGC = (QDM, PLL)
NLS = (DFL, RMX)
NQP = (FNM, JBQ)
JHV = (BRX, LCB)
QDK = (RHC, TDX)
TFC = (HXH, HXH)
PPH = (XKS, JLP)
SFD = (BCN, PDX)
VTN = (PMB, RFZ)
XTN = (JXL, VDM)
GJL = (PFP, KQH)
RDL = (NFR, VMT)
RKN = (NSD, TQV)
SXQ = (RPP, JTX)
KBM = (XLR, FFM)
KBP = (QHL, RTR)
BSJ = (JGX, GGG)
PSD = (GHB, NLC)
SJH = (VNL, GCN)
FNC = (PRP, JQL)
TVQ = (RGT, CFH)
JXT = (SVV, VQK)
RXL = (TTK, BDP)
KHD = (JTG, QLQ)
MKX = (SVV, VQK)
KQH = (CTC, XXX)
NLR = (CJK, HDF)
MKJ = (VJC, VGR)
RFC = (NLC, GHB)
FCJ = (FCD, JFC)
KNP = (KVK, QKB)
HFV = (BSM, HMV)
NSJ = (BBT, NQD)
HCR = (CVT, TXN)
FCG = (DKK, QXJ)
KTB = (HRR, VDV)
LMH = (LMM, LMM)
SVL = (LJG, DVG)
VHG = (LMT, SHD)
NXL = (FDK, VBR)
HVJ = (FTH, GDD)
QDX = (MXS, RMJ)
KTV = (MTG, RMV)
SCJ = (RFC, PSD)
XPG = (FLL, FPG)
BRX = (SHN, DDN)
TDN = (QHP, HTL)
PHL = (XPD, PCF)
QDM = (MBM, CVP)
MFF = (HDR, HHR)
CPV = (FQP, JBL)
VSN = (VXL, NLS)
JVG = (LFP, MVC)
DFL = (CJT, HSK)
QQJ = (SCJ, BGM)
HKP = (QFQ, QDS)
JFN = (FML, KKR)
CTL = (VXC, PNT)
GSC = (MNC, QMK)
FGS = (SHK, SHK)
FDQ = (LMQ, DJK)
LLQ = (TXH, RLG)
MGG = (QKQ, XCQ)
BPP = (LNV, FKM)
KLQ = (TDD, QCC)
MXS = (DMQ, XVK)
BFH = (SHS, TPX)
QMQ = (SLB, PPG)
BBT = (HRP, JDR)
GBR = (CLS, KMG)
MKG = (MNV, XFQ)
VRT = (QJQ, STK)
DHV = (FPC, JCM)
VBR = (CLV, XDN)
FPV = (JBG, CPG)
FDX = (MQF, FSL)
JBG = (HQS, TRD)
KJK = (DKK, QXJ)
MMB = (DMH, VDC)
BVK = (JGC, HXT)
PPC = (STP, MRF)
LMT = (JXK, KGS)
PTF = (XPG, HCH)
CQC = (SCM, NNR)
BHH = (HMN, KSS)
SHN = (CHN, MMR)
LNV = (NTN, TJK)
TJF = (HHJ, NNC)
FSK = (JNQ, XGH)
JKD = (PBG, QHK)
NPS = (CPG, JBG)
BKG = (GSC, SLT)
CNS = (VRK, XLJ)
RGM = (PRL, QFX)
QJH = (QJQ, STK)
PMB = (RRG, SCV)
QJM = (TQV, NSD)
DKK = (RMC, KXH)
HKV = (PDX, BCN)
FBB = (VTG, QBN)
FMV = (HTN, LVX)
RMV = (LPK, HQQ)
KXH = (CBH, KPT)
XLV = (PLL, QDM)
FDT = (VLS, TVH)
RJP = (DBL, GKV)
JXL = (QLR, NVD)
LFM = (BNB, SXT)
MQP = (NFD, XRB)
DJH = (NTT, HPP)
FNR = (HNB, SKV)
SHQ = (SGT, SRS)
QLB = (KVM, GNZ)
XGN = (MGG, PRR)
PCF = (KHD, PFL)
PBS = (VCJ, PPM)
XBG = (FLG, KSG)
BDQ = (MNS, HQL)
XCB = (RJP, CXN)
SXL = (HTF, BBL)
DMH = (JGV, FNS)
RGS = (NSR, BXS)
HHJ = (HBN, LBF)
NKS = (KTM, GDS)
PTV = (JJG, LGQ)
VXC = (TST, QSR)
PFL = (JTG, QLQ)
RQQ = (SMQ, PTF)
NTT = (JTJ, FNF)
LCB = (DDN, SHN)
GQL = (HDR, HHR)
HHF = (CJD, MHD)
FQN = (LRB, FNR)
BKF = (GBX, PBS)
TSQ = (PPC, FJX)
RRF = (CNS, HTK)
DPP = (CGM, LVF)
DNS = (RXN, KHV)
GKH = (TXH, RLG)
TVG = (DVG, LJG)
XBP = (PSS, TTN)
CXN = (GKV, DBL)
FGG = (PTL, BLB)
TBM = (FVL, VVN)
CFQ = (JBP, NXD)
FNB = (LDN, TBN)
VDF = (GLX, FMJ)
PQM = (MPR, PQC)
MCS = (VNV, JNB)
SFJ = (KHF, RVG)
GBH = (CXN, RJP)
DML = (FBB, NDF)
QRB = (BGL, BDQ)
CXB = (NLP, JKJ)
GCP = (BSJ, PKP)
KTM = (CQC, TRB)
BPV = (CDN, RTV)
TVS = (SHK, KVD)
BDP = (PHL, CFC)
HXK = (CGL, XDS)
XSG = (TVG, SVL)
HHR = (FGS, TVS)
RTF = (NDF, FBB)
LHH = (GCV, GCV)
NXD = (JVG, LBQ)
HTF = (QMH, HPV)
TVB = (CBM, CCQ)
FCF = (JNB, VNV)
RFZ = (SCV, RRG)
DJK = (TLN, BPP)
TTK = (CFC, PHL)
CLM = (BNC, TMG)
TDH = (HTK, CNS)
PHM = (RHM, CJM)
SHS = (SPJ, KRK)
SHM = (KVM, KVM)
TTR = (XTB, GXS)
QFX = (FMR, NSJ)
LXR = (GJK, JFR)
VSP = (FCD, JFC)
XSX = (RMJ, MXS)
GHQ = (TXK, DXP)
TXH = (KBC, XMQ)
BVC = (MDH, RBB)
VKH = (MNV, XFQ)
DBL = (XVQ, NHS)
GDD = (BTK, VSN)
FSC = (CFQ, DRK)
JJG = (TQM, JPV)
PBG = (FHB, CMD)
VBN = (PTL, BLB)
BLB = (LMH, QXF)
PPG = (TFC, TGC)
DPC = (KJK, FCG)
PTJ = (TPN, SHQ)
JLS = (CJM, RHM)
RHC = (MFF, GQL)
GXV = (SXL, GFG)
XTH = (JFG, FJJ)
RDX = (STR, XTN)
GBJ = (SHS, TPX)
SHL = (CQK, DPG)
KHV = (RCH, BDZ)
QFN = (MBD, KRJ)
FGT = (TPQ, KBF)
GHK = (MQG, QRB)
SRS = (HPM, MSQ)
MRF = (BVK, FVR)
DMQ = (QGJ, JLG)
PXV = (VXC, PNT)
NSP = (JFR, GJK)
TPB = (VBR, FDK)
DDN = (MMR, CHN)
DMG = (FJX, PPC)
MHR = (SCC, SCC)
RKR = (BKF, HMS)
JFJ = (BHH, RRD)
PSG = (GSG, KTB)
PRP = (GVJ, CDG)
THL = (TJF, MDQ)
GJK = (VCD, BGK)
GLM = (JFG, FJJ)
JQS = (CFK, JFJ)
JTX = (SMN, TLP)
CDG = (BPV, GQB)
SXN = (FSK, MNF)
FCK = (VDH, CKR)
DSH = (TNR, RTL)
BGM = (RFC, PSD)
FJJ = (HRL, LPD)
FLL = (TBM, JQX)
MHS = (QGV, LSD)
FKM = (TJK, NTN)
JFB = (JHV, XRL)
RPP = (TLP, SMN)
NTN = (TBJ, DTN)
KMG = (KPH, FRJ)
NSM = (VLS, TVH)
KFL = (XCM, PJG)
SXT = (BKT, HJP)
NSD = (TNX, MTD)
VNL = (HMT, DGR)
MSL = (MCS, FCF)
PQC = (DNG, NLQ)
NDS = (VGR, VJC)
PDK = (PHR, GVH)
HMS = (PBS, GBX)
VQS = (QBB, NLR)
NNR = (HNX, MSL)
CCQ = (PSG, RQK)
JCN = (KBF, TPQ)
JLG = (GTJ, DJH)
JFC = (HKK, JSG)
XGK = (BVJ, TVB)
DFG = (LHC, SFH)
GTJ = (NTT, HPP)
CLS = (FRJ, KPH)
QMB = (JLS, PHM)
GSR = (VPL, GGP)
CPQ = (SHL, DNQ)
PFQ = (XKS, JLP)
LBR = (LFM, PCK)
TLS = (HXD, SSL)
QDF = (TBN, LDN)
DHL = (GGQ, RDX)
QJQ = (QMB, LNP)
BVV = (TJL, QQJ)
FNM = (GJL, GJB)
MLA = (VNL, GCN)
TXK = (HKP, DGV)
LDJ = (PQC, MPR)
QPF = (HMK, KJD)
HQL = (MCT, KFL)
FPG = (TBM, JQX)
MNF = (JNQ, XGH)
JQL = (CDG, GVJ)
QMH = (RST, NQP)
GCR = (LBR, HBF)
CBH = (HNS, XXG)
MQF = (JCN, FGT)
QJD = (XGN, NVN)
QDS = (TDG, NKS)
MDH = (TLS, XQN)
JFG = (HRL, LPD)
QKB = (LSF, FQN)
LND = (SLB, PPG)
XKJ = (FHG, BFK)
JKC = (RTL, TNR)
QGJ = (GTJ, DJH)
PCK = (BNB, SXT)
KVK = (LSF, FQN)
NXS = (FDT, NSM)
QMK = (QBR, GCP)
SQK = (LQK, NSG)
TPQ = (XLV, DGC)
MDQ = (HHJ, NNC)
HCH = (FPG, FLL)
BRB = (BJR, RJF)
TDX = (MFF, GQL)
PSS = (CLM, NBP)
KHJ = (MNF, FSK)
RHM = (SHC, QML)
FNF = (FNQ, DHV)
VVN = (PJN, VQB)
TPF = (PRP, JQL)
CDN = (DHL, BKJ)
TPX = (SPJ, KRK)
DNQ = (CQK, DPG)
KJD = (GLM, XTH)
GCL = (LHC, SFH)
JQB = (QPF, KCX)
FPC = (SFD, HKV)
VQK = (XCB, GBH)
FNS = (RRF, TDH)
LLC = (QGV, LSD)
DXR = (NPS, FPV)
BHN = (NSL, PSF)
JGD = (KNG, XKG)
XXG = (JNM, NSK)
BPB = (JXT, MKX)
FTH = (BTK, VSN)
GVH = (DFG, GCL)
BVN = (BHN, TBQ)
TPN = (SGT, SRS)
TST = (CLX, TTR)
JNB = (PQM, LDJ)
LVF = (SFJ, BVH)
VXL = (RMX, DFL)
TJS = (FKB, SXB)
HMV = (TRL, PSC)
SCM = (HNX, MSL)
BRF = (NSP, LXR)
RGT = (QDT, DXR)
VNV = (PQM, LDJ)
NQD = (HRP, JDR)
GDQ = (JCX, RKR)
XQD = (XCH, MJC)
VCD = (SMV, LNS)
NBX = (BQG, SDG)
HKR = (DJK, LMQ)
JNQ = (KGX, PDK)
VMG = (FCK, XPL)
PHR = (GCL, DFG)
KBC = (RKX, CPQ)
HRL = (VDF, JXD)
NVN = (PRR, MGG)
DPV = (GGP, VPL)
LGL = (QHL, RTR)
TRD = (RGM, NRV)
LPD = (VDF, JXD)
QHL = (XDK, XNP)
BXL = (SXL, GFG)
CGL = (CNP, TVR)
GJR = (QPF, KCX)
QBN = (KJC, HCR)
FHG = (SJH, SJH)
BVJ = (CCQ, CBM)
XFQ = (JNV, BKG)
HQS = (RGM, NRV)
CPG = (HQS, TRD)
NHS = (RTF, DML)
SHK = (XQD, XQD)
KXR = (DQX, RSX)
NLQ = (KLQ, JXP)
QKQ = (HVJ, MMT)
DKB = (NPF, XBP)
BTK = (NLS, VXL)
CTC = (CTL, PXV)
VBD = (LMT, SHD)
JBL = (HHF, NNX)
CMV = (DRX, RHV)
LSD = (NJM, CHD)
TPG = (JTX, RPP)
DMN = (GSR, DPV)
JXK = (FGG, VBN)
GGQ = (XTN, STR)
GJF = (CGM, LVF)
GSN = (VJQ, CKG)
VLS = (GFS, GHM)
QBB = (CJK, HDF)
JXD = (GLX, FMJ)
RLG = (KBC, XMQ)
JQX = (VVN, FVL)
LRP = (QBB, NLR)
LGQ = (TQM, JPV)
BNB = (HJP, BKT)
VJC = (QJD, DLN)
FDK = (XDN, CLV)
CFH = (QDT, DXR)
NRV = (QFX, PRL)
CNT = (FCJ, VSP)
KPZ = (GCN, VNL)
KRJ = (DBQ, KBM)
CRJ = (VQL, BFG)
DTN = (GXM, QFN)
HTN = (XGK, CVM)
FJX = (MRF, STP)
PNT = (QSR, TST)
RHV = (KTV, HSX)
CFK = (RRD, BHH)
VDH = (BRF, QXQ)
SFH = (LHH, SBH)
MBT = (HSV, VDG)
RMJ = (XVK, DMQ)
CJD = (TMR, MMB)
VJQ = (FNB, QDF)
DLN = (XGN, NVN)
SDG = (HHG, FSC)
KGS = (FGG, VBN)
SGT = (MSQ, HPM)
JBQ = (GJL, GJB)
GCN = (DGR, HMT)
MNP = (CFK, JFJ)
DMT = (GDQ, QFB)
STP = (FVR, BVK)
TQR = (FCK, XPL)
HBF = (PCK, LFM)
MBD = (DBQ, KBM)
HNS = (NSK, JNM)
RSX = (NDS, MKJ)
HXD = (MHR, FJM)
KVM = (CMV, KRP)
SLT = (QMK, MNC)
PFP = (XXX, CTC)
TGC = (HXH, DNS)
GDS = (CQC, TRB)
TMG = (CNT, KKQ)
BQA = (VHX, MQS)
GFG = (BBL, HTF)
JCR = (QRB, MQG)
TQM = (KNP, QNN)
GLX = (VKC, NDM)
KSG = (LLQ, GKH)
JVP = (BDP, TTK)
TXN = (JFB, CPF)
GJB = (PFP, KQH)
DVG = (JCR, GHK)
BGC = (FKB, SXB)
VDC = (FNS, JGV)
BKJ = (RDX, GGQ)
NFR = (KHJ, SXN)
XVQ = (RTF, DML)
VRC = (DPV, GSR)
TNR = (GHQ, XRP)
JSS = (LGQ, JJG)
PDX = (DMN, VRC)
PPM = (XHK, DKB)
HDR = (FGS, FGS)
MJA = (CMV, KRP)
CFC = (PCF, XPD)
GXM = (KRJ, MBD)
NLC = (JTN, FVN)
DRX = (HSX, KTV)
CCH = (HCJ, HGM)
TRB = (NNR, SCM)
SSL = (MHR, FJM)
QRC = (MHS, LLC)
RTR = (XDK, XNP)
QLT = (BVC, DSM)
LJG = (JCR, GHK)
HMK = (GLM, XTH)
TVR = (JQB, GJR)
JCX = (BKF, HMS)
TNX = (BFH, GBJ)
SMQ = (XPG, HCH)
LSL = (TDX, RHC)
PFD = (PTV, JSS)
JGV = (TDH, RRF)
NFJ = (XKG, KNG)
CPP = (FMV, TFR)
GNZ = (KRP, CMV)
XCL = (XDR, JFN)
QJN = (DMT, TGX)
DBQ = (FFM, XLR)
RMX = (CJT, HSK)
PLL = (MBM, CVP)
TQV = (TNX, MTD)
FLG = (LLQ, GKH)
GTF = (CPP, QTV)
JLP = (BLM, HPD)
TLN = (FKM, LNV)
LMM = (CDJ, CDJ)
QPD = (PTF, SMQ)
CBM = (RQK, PSG)
JKJ = (NFJ, JGD)
NSL = (XCL, PNC)
RST = (JBQ, FNM)
GBG = (VMT, NFR)
MPR = (DNG, NLQ)
MSQ = (MCR, GTF)
JTN = (QCX, KKM)
CKG = (QDF, FNB)
TRL = (DPC, XSV)
SVV = (XCB, GBH)
NVD = (VRT, QJH)
GHM = (XVJ, GFN)
NFD = (QRC, XJL)
HPD = (QMQ, LND)
QFB = (RKR, JCX)
DRK = (NXD, JBP)
DQX = (MKJ, NDS)
TGX = (GDQ, QFB)
JTJ = (FNQ, DHV)
DSM = (RBB, MDH)
TVH = (GHM, GFS)
RBV = (HMV, BSM)
KBF = (XLV, DGC)
KSS = (DPP, GJF)
CNP = (JQB, GJR)
HGM = (VMG, TQR)
GGP = (GFJ, TVQ)
GVD = (HTL, QHP)
TMR = (VDC, DMH)
FCD = (JSG, HKK)
MNV = (JNV, BKG)
HRJ = (VJQ, CKG)
HXB = (KSG, FLG)
DJX = (MQP, RFN)
CJM = (SHC, QML)
VDV = (LRP, VQS)
LCR = (LQK, NSG)
RTL = (GHQ, XRP)
XDR = (KKR, FML)
JCL = (GVD, TDN)
LVX = (CVM, XGK)
RKX = (SHL, DNQ)
FRJ = (JDP, QMR)
TMZ = (MJC, XCH)
LPK = (LMK, CCH)
JDP = (GSN, HRJ)
KPT = (HNS, XXG)
HDN = (QQJ, TJL)
LTH = (DSM, BVC)
NDF = (QBN, VTG)
DKV = (NSM, FDT)
JGX = (NVL, QTJ)
HBN = (BXL, GXV)
BGR = (SVL, TVG)
LBF = (GXV, BXL)
GBX = (PPM, VCJ)
MXB = (HSV, VDG)
XMQ = (RKX, CPQ)
AAA = (TPN, SHQ)
NDM = (QJM, RKN)
XQN = (HXD, SSL)
QML = (XHF, THL)
MNS = (KFL, MCT)
JNM = (FNC, TPF)
NNX = (CJD, MHD)
VKC = (RKN, QJM)
XRL = (BRX, LCB)
PNC = (JFN, XDR)
GHB = (JTN, FVN)
CJK = (VKH, MKG)
PRR = (XCQ, QKQ)
HXH = (RXN, RXN)
BXD = (KXR, RXS)
VPL = (GFJ, TVQ)
DPF = (MQP, RFN)
STK = (QMB, LNP)
DGR = (CPV, GSF)
XHF = (MDQ, TJF)
GFJ = (CFH, RGT)
DXP = (DGV, HKP)
QMR = (HRJ, GSN)
VTG = (KJC, HCR)
LRM = (JSS, PTV)
DNG = (KLQ, JXP)
BFK = (SJH, KPZ)
TBJ = (GXM, QFN)
RFN = (XRB, NFD)
MTG = (LPK, HQQ)
VTT = (SHM, QLB)
NJQ = (CDJ, VTN)
HHG = (DRK, CFQ)
STR = (VDM, JXL)
LTF = (TPL, FDX)
PJN = (MLR, CXB)
XGH = (KGX, PDK)
QLQ = (GCR, RMK)
XTB = (VHG, VBD)
CKR = (BRF, QXQ)
KKQ = (FCJ, VSP)
QCX = (GBR, DMB)
HNB = (PTJ, PTJ)
TDG = (KTM, GDS)
GRC = (TDN, GVD)
XJL = (LLC, MHS)
QSR = (CLX, TTR)
RXS = (DQX, RSX)
HJK = (BQG, SDG)
GVJ = (GQB, BPV)
KGX = (GVH, PHR)
JGC = (BXD, PGT)
CQK = (TSQ, DMG)
RQK = (GSG, KTB)
LFP = (JQS, MNP)
HKK = (RQQ, QPD)
XSV = (KJK, FCG)
TJL = (BGM, SCJ)
VFV = (RDL, GBG)
HDF = (MKG, VKH)
TGA = (RRG, SCV)
VDG = (NBX, HJK)
CLV = (MXB, MBT)
LQK = (QLT, LTH)
JNV = (GSC, SLT)
FQP = (NNX, HHF)
SCC = (SHM, SHM)
LSF = (LRB, LRB)
HPM = (GTF, MCR)
GFS = (GFN, XVJ)
XCQ = (HVJ, MMT)
QTJ = (HDN, BVV)
NNC = (HBN, LBF)
RRG = (GPS, BVN)
SJN = (QDX, XSX)
BQG = (FSC, HHG)
XPL = (VDH, CKR)
QXF = (LMM, NJQ)
LMK = (HCJ, HGM)
DHJ = (TPL, FDX)
VQL = (TJS, BGC)
BGL = (HQL, MNS)
RMK = (LBR, HBF)
FVR = (JGC, HXT)
TFR = (LVX, HTN)
PTL = (LMH, QXF)
DGV = (QFQ, QDS)
KKM = (GBR, DMB)
XVJ = (HXB, XBG)
GQB = (CDN, RTV)
XDN = (MBT, MXB)
QLR = (VRT, QJH)
FFM = (BGR, XSG)
XRB = (XJL, QRC)
GKV = (XVQ, NHS)
VHX = (DKV, NXS)
HPP = (FNF, JTJ)
XRP = (TXK, DXP)
XKG = (GRC, JCL)
FNQ = (JCM, FPC)
BJQ = (VQL, BFG)
HRP = (VFV, HJM)
SMN = (KBP, LGL)
JSG = (RQQ, QPD)
NSK = (FNC, TPF)
VRK = (FDQ, HKR)
MLR = (NLP, JKJ)
FVL = (PJN, VQB)
GXS = (VBD, VHG)
NSR = (CRJ, BJQ)
GCV = (FHG, FHG)
CVM = (BVJ, TVB)
SLB = (TFC, TGC)
KKR = (CSR, BRB)
RBB = (XQN, TLS)
RXN = (RCH, RCH)
GPS = (TBQ, BHN)
HTK = (VRK, XLJ)
HJM = (RDL, GBG)
KJC = (CVT, TXN)
BBL = (QMH, HPV)
SBH = (GCV, XKJ)
HSX = (RMV, MTG)
CDJ = (PMB, PMB)
FKB = (PPH, PFQ)
FSL = (FGT, JCN)
BFG = (BGC, TJS)
HRR = (LRP, VQS)
LRB = (HNB, HNB)
VGR = (QJD, DLN)
FMJ = (NDM, VKC)
KRP = (DRX, RHV)
BTQ = (XDS, CGL)
QHP = (RXL, JVP)
JCM = (HKV, SFD)
SMV = (VHL, QJN)
LNP = (PHM, JLS)
XDK = (SQK, LCR)
PDV = (BXS, NSR)
PJG = (SJN, GPC)
VHL = (DMT, TGX)
ZZZ = (SHQ, TPN)
QGV = (NJM, CHD)
GFN = (XBG, HXB)
JJM = (JXT, MKX)
QNN = (KVK, QKB)
QHK = (FHB, CMD)
XNP = (LCR, SQK)
RRD = (HMN, KSS)
HJP = (SXQ, TPG)
QXQ = (LXR, NSP)
VQB = (MLR, CXB)
JDR = (HJM, VFV)
HSV = (HJK, NBX)
PKP = (GGG, JGX)
PGT = (KXR, RXS)
PRL = (NSJ, FMR)
CVP = (PFD, LRM)
TLP = (KBP, LGL)
CSR = (BJR, RJF)
DPG = (DMG, TSQ)
RJF = (JJM, BPB)
LDN = (JKD, HRM)
TBQ = (NSL, PSF)
BCN = (VRC, DMN)
SPJ = (RGS, PDV)
CHN = (HFV, RBV)
KHF = (DJX, DPF)
BDZ = (MQS, VHX)
XLJ = (FDQ, HKR)
FVN = (QCX, KKM)
VCJ = (XHK, DKB)
NLP = (NFJ, JGD)
CPF = (JHV, XRL)
GSG = (HRR, VDV)
PSF = (PNC, XCL)
TPL = (FSL, MQF)
TTN = (NBP, CLM)
XXX = (PXV, CTL)
SXB = (PPH, PFQ)
HMN = (GJF, DPP)
CHD = (LSL, QDK)
HPV = (RST, NQP)
CVT = (CPF, JFB)
QXJ = (RMC, KXH)
JPV = (KNP, QNN)
GGG = (NVL, QTJ)
RVG = (DJX, DPF)
MJC = (JKC, DSH)
XDS = (TVR, CNP)
CMD = (LTF, DHJ)
MQS = (NXS, DKV)
RTV = (BKJ, DHL)
NBP = (BNC, TMG)
FMR = (NQD, BBT)
XHK = (XBP, NPF)
QBR = (PKP, BSJ)
RCH = (VHX, MQS)
BNC = (CNT, KKQ)
HXT = (PGT, BXD)
MTD = (GBJ, BFH)
HTL = (RXL, JVP)
MMR = (HFV, RBV)
FHB = (DHJ, LTF)
QDT = (FPV, NPS)
MMT = (GDD, FTH)
KCX = (KJD, HMK)
XPD = (PFL, KHD)
KNG = (GRC, JCL)
HCJ = (TQR, VMG)
GPC = (XSX, QDX)
FJM = (SCC, VTT)
XCM = (SJN, GPC)
BSM = (TRL, PSC)
HSK = (HXK, BTQ)
MVC = (MNP, JQS)
JXP = (TDD, QCC)
SKV = (PTJ, ZZZ)
QCC = (TPB, NXL)
CJT = (HXK, BTQ)
KRK = (PDV, RGS)
SHC = (XHF, THL)
MQG = (BDQ, BGL)
HMT = (CPV, GSF)
SCV = (BVN, GPS)
QFQ = (NKS, TDG)
BXS = (CRJ, BJQ)
LHC = (LHH, SBH)
QTV = (TFR, FMV)
NVL = (HDN, BVV)
BKT = (TPG, SXQ)
JFR = (VCD, BGK)
GSF = (JBL, FQP)
TDD = (NXL, TPB)
PSC = (DPC, XSV)
MCR = (QTV, CPP)
MHD = (MMB, TMR)
NPF = (PSS, TTN)
TBN = (JKD, HRM)
RMC = (KPT, CBH)
DMB = (CLS, KMG)
BLM = (QMQ, LND)
NJM = (QDK, LSL)
FML = (BRB, CSR)
LNS = (QJN, VHL)
BJA = (XCH, MJC)
JBP = (JVG, LBQ)
KVD = (XQD, TMZ)
LMQ = (BPP, TLN)
BVH = (RVG, KHF)
XCH = (JKC, DSH)
HQQ = (LMK, CCH)
XKS = (HPD, BLM)
BGK = (SMV, LNS)
MBM = (LRM, PFD)
MCT = (XCM, PJG)";

await Runner.RunCodeWithTimer(1, async () =>
{
    var instructions = LeftRightInstructions.ParsePart1(INSTRUCTIONS);
    var steps = await instructions.CalculateStepsPart1();

    Console.WriteLine($"Number of steps: {steps}");
});

await Runner.RunCodeWithTimer(2, async () =>
{
    var instructions = LeftRightInstructions.ParsePart2(INSTRUCTIONS);
    var steps =  await instructions.CalculateStepsPart2WithPath();

    Console.WriteLine($"Number of steps: {steps}");
});