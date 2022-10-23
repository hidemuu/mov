import { ApiContext, User } from '../../@types/data'
import { fetcher } from '../../utils/fetcher'

export type GetUserParams = {
    id: number
}

const getUser = async(context: ApiContext, {id}: GetUserParams): Promise<User> => {
    
    return await fetcher(`${context.apiRootUrl.replace(/\/$/g, '')}/users/${id}`,
    {
        headers: {
            Accept: 'application/json',
            'Content-type': 'application/json',
        },
    },)
}

export default getUser