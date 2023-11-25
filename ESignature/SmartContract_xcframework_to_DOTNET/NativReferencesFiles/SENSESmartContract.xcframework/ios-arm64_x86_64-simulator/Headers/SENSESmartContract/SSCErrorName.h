//
//  SSCErrorName.h
//  sense-smartcontract-sdk-ios
//
//  Created by Marc-Henri Primault on 02.02.18.
//  Copyright © 2018 Marc-Henri Primault. All rights reserved.
//

/**
 * Main SENSE Smart Contract error domain
 */
extern NSString *const SSC_ERROR_DOMAIN;

/**
 * SSC_ERROR_CODE_USER_NOT_LOGGED
 *
 * Means that you try to execute an action whitout user logged in.
 * But the action require that the user must be logged in.
 */
extern NSInteger const SSC_ERROR_CODE_USER_NOT_LOGGED;

/**
 * SSC_ERROR_CODE_ENROLLMENT_NOT_ALLOWED
 *
 * Means that you try to enroll a user but the enrollment code
 * is wrong, already used or expired, or the username is unknown.
 */
extern NSInteger const SSC_ERROR_CODE_ENROLLMENT_NOT_ALLOWED;

/**
 * SSC_ERROR_CODE_KEY_PAIR_GENERATION
 *
 * Means that key pair generation failed.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_KEY_PAIR_GENERATION;

/**
 * SSC_ERROR_CODE_KEY_PAIR_UNKNOWN
 *
 * Means that key pair is not found or corrupted in the keychain.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_KEY_PAIR_UNKNOWN;

/**
 * SSC_ERROR_CODE_CERTIFICATE_CSR_REQUEST
 *
 * Means that CSR request to obtain the certificate provided
 * by the PKI server failed.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_CERTIFICATE_CSR_REQUEST;

/**
 * SSC_ERROR_CODE_CERTIFICATE_GENERATION
 *
 * Means that the certificate provided by the PKI server has
 * an invalid format.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_CERTIFICATE_GENERATION;

/**
 * SSC_ERROR_CODE_CERTIFICATE_TRUST
 *
 * Means that the certificate provided by the PKI server is
 * not trusted by the application.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_CERTIFICATE_TRUST;

/**
 * SSC_ERROR_CODE_CERTIFICATE_SAVE
 *
 * Means that the certificate provided by the PKI server is
 * not saved in the keychain by the application.
 *
 * @warning The user is disenrolled if this error occurs.
 */
extern NSInteger const SSC_ERROR_CODE_CERTIFICATE_SAVE;

/**
 * Specific domain for JSON RPC
 */
extern NSString *const SSC_ERROR_DOMAIN_JSON_RPC;

/**
 * SSC_ERROR_CODE_JSON_RPC_REQUEST_INVALID
 *
 * Means that the JSON request format to send is invalid.
 */
extern NSInteger const SSC_ERROR_CODE_JSON_RPC_REQUEST_INVALID;

/**
 * SSC_ERROR_CODE_JSON_RPC_RESPONSE_VERSION_NOT_2_0
 *
 * Means that the JSON response format is not 2.0.
 * @See http://www.jsonrpc.org/specification
 */
extern NSInteger const SSC_ERROR_CODE_JSON_RPC_RESPONSE_VERSION_NOT_2_0;

/**
 * SSC_ERROR_CODE_JSON_RPC_RESPONSE_FORMAT_INVALID
 *
 * Means that the JSON response format is invalid.
 */
extern NSInteger const SSC_ERROR_CODE_JSON_RPC_RESPONSE_FORMAT_INVALID;

