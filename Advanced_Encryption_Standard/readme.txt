本程序集为128位密钥高级加密标准,有两个公共方法:
1.AES.Encrypt(System.String plaintext)
使用AES加密明文plaintext返回密文字符串,如果明文为空字符串、null或数据加密异常则返回空字符串
2.AES.Decrypt(System.String ciphertext)
使用AES解密密文ciphertext(Base64字符串)返回明文字符串,如果密文为空字符串、null及非Base64字符串或解密异常则返回空字符串

此加密算法密钥未公开，如有特殊需求，请致信ftd314159@163.com，谢谢使用！