extern "C"
{
    char* MakeStringCopy (const char* string)
    {
        if (string == NULL)
            return NULL;
        
        char* res = (char*)malloc(strlen(string) + 1);
        strcpy(res, string);
        return res;
    }

    char* GetVersionName_()
    {
        NSString *buildNo = [[[NSBundle mainBundle] infoDictionary] objectForKey:@"CFBundleShortVersionString"];
        return MakeStringCopy( [buildNo UTF8String] );
    }

    char* GetBuildVersionName_()
    {
        NSString *buildNo = [[[NSBundle mainBundle] infoDictionary] objectForKey:@"CFBundleVersion"];
        return MakeStringCopy( [buildNo UTF8String] );
    }
}
