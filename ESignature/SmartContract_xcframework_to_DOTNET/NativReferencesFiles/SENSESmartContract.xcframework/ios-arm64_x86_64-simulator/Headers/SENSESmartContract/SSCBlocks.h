//
//  SSCBlocks.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 31.01.18.
//  Copyright © 2018 Marc-Henri Primault. All rights reserved.
//

#import "SSCContract.h"
#import "SSCContractResponse.h"
#import "SSCSignatureStatus.h"
#import "SSCVisualSignature.h"

typedef void (^SSCContractsBlock)(NSArray<SSCContract *> *contracts, NSError *error);
typedef void (^SSCContractBlock)(SSCContract *contract, NSError *error);
typedef void (^SSCContractResponseBlock)(SSCContractResponse *contractResponse, NSError *error);
typedef void (^SSCSignatureStatusBlock)(SSCSignatureStatus *signatureStatus, NSError *error);
typedef void (^SSCVisualSignaturesBlock)(NSArray<SSCVisualSignature*>* visualSignatures, NSError *error);
typedef void (^SSCVisualSignatureBlock)(SSCVisualSignature* visualSignature, NSError *error);
typedef void (^SSCErrorBlock)(NSError *error);
