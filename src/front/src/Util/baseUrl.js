
const DEV = 'DEV'
const PROD = 'PROD'

/*-----------------------------------------*/
/*------*/ export const environment = DEV /* <------- Altere DEV / PROD para publicar */
/*-----------------------------------------*/

export const baseURL =
    environment === DEV ? 'http://localhost:9000/api/': 'http://localhost:9000/api/'
