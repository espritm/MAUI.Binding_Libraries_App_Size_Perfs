//
//  SENStreamConnectionService.h
//  sense-ios-core
//
//  Created by Marc-Henri Primault on 11.11.13.
//  Copyright (c) 2013 Sysmosoft. All rights reserved.
//

@interface SSCJSONRPCService : NSObject

- (id)initWithApplicationRef:(NSString *)appRef;
- (void)requestWithService:(NSString *)service method:(NSString *)method completion:(void(^)(id, NSError *))completion;
- (void)requestWithService:(NSString *)service method:(NSString *)method params:(NSArray *)params completion:(void(^)(id, NSError *))completion;

@end
