﻿Console.WriteLine("Hello KKK World!");

// 1. 단축키(HotKey) : (단축키를 사용할 경우 프로세스의 키입력을 무시한다.)
Keyboard.HotKey(Keys.A,  () => { Console.WriteLine("a"); });

Keyboard.HotKey(Keys.A | Keys.Control, () => 
{
    Console.WriteLine("ctrl + a");
    // 현재 화면 캡쳐 및 자동 저장 (파일명: 현재 날짜)
    Camera.Capture().Save();
});

Keyboard.HotKey(Keys.A | Keys.Alt, () => 
{
    Console.WriteLine("alt + a");
    // 콘솔창 토글
    Command.visible = !Command.visible;
});

// 2. 키보드 전역 훅 : (다른 프로세스에서 키보드 입력을 해도 실행된다.)
// 2.1 키를 누를 때
Keyboard.OnKeyDown += (key) => 
{
    switch (key)
    {
        case Keys.B | Keys.Control: Console.WriteLine("Ctrl + B가 눌렸다."); break;
        case Keys.C: Console.WriteLine("C가 눌렸다."); break;
        // 쥴립 프로그램 종료
        case Keys.Z: Program.Exit("Zulip"); break;
        // 브라우저 실행
        case Keys.J: Program.Start(@"http://www.google.com"); break;
        // 쥴립 프로그램
        case Keys.S: Program.Show("Zulip"); break;
        case Keys.H: Program.Hide("Zulip"); break;
    }
};


// 2.2 키를 땔 때
Keyboard.OnKeyUp += (key) => {
    Console.WriteLine(key);
    
};

// 3. 테스트 함수
Test();
private void Test()
{
    Console.WriteLine("This is Test function..");
}

// 4. 마우스 전역 훅 : (다른 프로세스에서 마우스 입력을 해도 실행된다.)
Mouse.OnMouseDown += (x, y) =>
{
    Console.WriteLine(string.Format("click (x: {0}, y: {1})", x, y));
}