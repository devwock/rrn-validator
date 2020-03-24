# RrnValidator

주민등록번호/외국인등록번호 검증

## 사용법

### 주민등록번호/외국인등록번호 앞 6자리 검증 (생일)

```C#
RrnValidator rrnValidator = new RrnValidator();
bool isCorrect = rrnValidator.IsValidBirthday(rrnNumbers);
```

### 주민등록번호/외국인등록번호 앞 6자리 + 뒷 첫 자리 검증

```C#
RrnValidator rrnValidator = new RrnValidator();
bool isCorrect = rrnValidator.IsValidRrnFirst(rrnNumbers);
```

### 주민등록번호/외국인등록번호 전체 검증

```C#
RrnValidator rrnValidator = new RrnValidator();
bool isCorrect = rrnValidator.IsValidRrn(rrnNumbers);
```

## TODO

* 테스트 케이스 작성
