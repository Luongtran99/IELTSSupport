import sys
import language_check as t
tool = t.LanguageTool('en-US')
#print(sys.argv[1])
text = sys.argv[1];
matches = tool.check(text)

print(len(matches))
if len(matches) == 0:
    print("Khong")
else:
    for i in range(0,len(matches)):
        print("{}|{}|{}|{}".format(matches[i].fromx, matches[i].tox, matches[i].msg,matches[i].replacements))

