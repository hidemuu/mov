import { ApiContext, User } from '../../@types/data'
import { fetcher } from '../../utils/fetcher'

export type SigninParams = {
    username: string
    password: string
}

const signin = async(context: ApiContext, params: SigninParams): Promise<User> => {
    return await fetcher(`${context.apiRootUrl.replace(/\/$/g, '')}/auth/signin`, {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-type': 'application/json',
        },
        body: JSON.stringify(params),
    },)
}

export default signin