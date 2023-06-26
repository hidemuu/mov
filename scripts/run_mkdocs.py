import subprocess

# Mkdocsのディレクトリへ移動する
mkdocs_dir = '/path/to/mkdocs'
cmd = f'cd {mkdocs_dir} &&'

# Mkdocsのビルドを実行する
cmd += 'mkdocs build'

# コマンドを実行する
subprocess.call(cmd, shell=True)

# Mkdocsのサーバーを起動する
cmd = f'cd {mkdocs_dir} && mkdocs serve'

# コマンドを実行する
subprocess.call(cmd, shell=True)